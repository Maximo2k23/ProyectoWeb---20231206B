import "bootstrap/dist/css/bootstrap.min.css";
import Tarjeta from "./componentes/Tarjeta.js";
import TablaCategorias from "./componentes/TablaCategorias.js";
import ModalCategoria from "./componentes/ModalCategoria.js";

import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap";

import { useState, useEffect } from "react";

const App = () => {

    const [categorias, setCategorias] = useState([]);
    const [mostrarModal, setMostrarModal] = useState(false);
    const [editar, setEditar] = useState(null);



    const ConsumirAPI = async () => {
        const response = await fetch("/api/categorias/listar");

        if (response.ok) {
            const data = await response.json();
            console.log(data);
            setCategorias(data);
        }
    }

    useEffect(() => {
        ConsumirAPI();
    }, []);

    const guardarCategoria = async (categoria) => {
        const response = await fetch("/api/categorias/guardar", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(categoria)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            ConsumirAPI();
        }

    }

    const editarCategoria = async (categoria) => {
        const response = await fetch("/api/categorias/actualizar", {
            method: "PUT",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(categoria)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            ConsumirAPI();
        }

    }

    const eliminarCategoria = async (id) => {

        var respuesta = window.confirm('¿Está seguro que desea eliminar?');

        if (!respuesta) {
            return;
        }

        const response = await fetch("/api/categorias/eliminar/" + id, {
            method: "GET"
        })

        if (response.ok) {
            ConsumirAPI();
        }

    }


    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5> Lista de Categor&iacute;s</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nueva categor&iacute;a</Button>

                            <TablaCategorias
                                data={categorias}
                                setEditar={setEditar}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}
                                eliminarCategoria={eliminarCategoria}

                            />

                            <ModalCategoria
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}
                                guardarCategoria={guardarCategoria}
                                editar={editar}
                                setEditar={setEditar}
                                editarCategoria={editarCategoria}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Container>
    )
}

export default App;

