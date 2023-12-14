import {
    Button, Modal, ModalHeader, ModalBody,
    Form, FormGroup, Input, Label, ModalFooter
} from "reactstrap";

import { useEffect, useState } from "react";

const modeloCategoria = {
    idCategoria: 0,
    nombre: "",
    descripcion: ""
}

const ModalCategoria = ({ mostrarModal, setMostrarModal, guardarCategoria, editar, setEditar, editarCategoria,modeloEditar }) => {

    const [categoria, setCategoria] = useState(modeloCategoria);
    const actualizarDato = (e) => {
        console.log(e.target.name + " : " + e.target.value);
        setCategoria(
            {
                ...categoria,
                [e.target.name]: e.target.value
            }
        )
    }

    const enviarDatos = () => {
        if (categoria.IdCategoria === 0) {
            guardarCategoria(categoria);
        } else {
            editarCategoria(categoria);
        }
    }

    useEffect(() => {
        if (editar != null) {
            setCategoria(editar);
        } else {
            setCategoria(modeloCategoria);
        }
    }, [editar])

    return (
        <Modal isOpen={mostrarModal}>
            <ModalHeader>Nueva Categor&iacute;a</ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre:</Label>
                        <Input name="nombre" onChange={(e) => actualizarDato(e)}
                            value={categoria.nombre } />
                    </FormGroup>
                    <FormGroup>
                        <Label>Descripci&oacute;n:</Label>
                        <Input name="descripcion" onChange={(e) => actualizarDato(e)}
                            value={categoria.descripcion} />
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="success" size="sm" onClick={enviarDatos }>Guardar</Button>
                <Button color="danger" size="sm" onClick={ () => setMostrarModal(!mostrarModal) }>Cerrar</Button>
            </ModalFooter>
        </Modal>
    )
}
export default ModalCategoria;