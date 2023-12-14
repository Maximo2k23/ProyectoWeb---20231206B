import { Table , Button } from "reactstrap";

const TablaCategorias = ({ data, setEditar, mostrarModal, setMostrarModal, eliminarCategoria }) => {

    const enviarDatos = (categoria) => {
        setEditar(categoria);
        setMostrarModal(!mostrarModal)
    }
    return (
        <Table strip="true" responsive="true">
            <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Descripci&oacute;n</th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr><td>No hay registros</td></tr>
                    ): (
                            data.map((item) => (
                                <tr key={item.idCategoria}>
                                    <td>{item.idCategoria}</td>
                                    <td>{item.nombre}</td>
                                    <td>{item.descripcion}</td>
                                    <td>
                                        <Button color="primary" size="sm" className="me-2" onClick={() => enviarDatos(item) }>Editar</Button>
                                        <Button color="danger" size="sm" className="me-2" onClick={() => eliminarCategoria(item.idCategoria) }>Eliminar</Button>

                                    </td>
                                </tr>
                        ))
                    )
                }
            </tbody>
        </Table>
    )
}

export default TablaCategorias;