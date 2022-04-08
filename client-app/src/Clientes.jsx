import React, { useState, useEffect } from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { PageHeader, Button, Descriptions, Modal, Form, Input, Upload, message } from 'antd';
import { UploadOutlined, InboxOutlined } from '@ant-design/icons';
import clientesApi from "./service/clientes";
import { Table } from 'antd';
import { formatCountdown } from 'antd/lib/statistic/utils';

export default function Clientes() {
    const [cliente, setClientes] = useState([]);
    const [busqueda, setBusqueda] = useState([]);
    const [tablaClientes, setTablaClientes] = useState([]);

    const [isModalOpen, setIsModalOpen] = useState(false);

    const [form] = Form.useForm();
    /* 
        const normFile = (e) => {
            console.log('Upload event:', e);
    
            if (Array.isArray(e)) {
                return e;
              }
            
              return e && e.fileList;
            }; */

    const handleChange = e => {
        setBusqueda(e.target.value);
        filtrar(e.target.value);
    }

    const filtrar = (palabraBusqueda) => {
        var resultadoBusqueda = tablaClientes.filter((elemento) => {
            if (elemento.cedula.toString().toLowerCase().includes(palabraBusqueda.toLowerCase())
            ) {
                return elemento;
            }
        });
        setClientes(resultadoBusqueda);
    }

    useEffect(() => {
        clientesApi.getAll().then((data) => setClientes(data))
        clientesApi.getAll().then((dat) => setTablaClientes(dat))
    }, []);

    return (

        <div className="site-page-header-ghost-wrapper">
            <PageHeader
                ghost={false}
                onBack={() => window.history.back()}
                title="Clientes"
                extra={[
                    <Button key="1" type="primary" onClick={() => { setIsModalOpen(true) }}>
                        Nuevo cliente
                    </Button>,
                ]}>
            </PageHeader>

            <div className='Cliente'>
                <div className='containerInput'>
                    <input
                        className="form-control"
                        value={busqueda}
                        placeholder="Búsqueda por cédula"
                        onChange={handleChange}
                    />
                    <button className="btn btn-primary button">
                        Buscar
                    </button>
                </div>

                <div className='Cliente'>
                    <div className="table-responsive">
                        <table className="table table-sm table-bordered">
                            <thead className="thead-dark">
                                <tr>
                                    <th>Nombre</th>
                                    <th>Apellido</th>
                                    <th>Cédula</th>
                                    <th>Dirección</th>
                                    <th>Sector</th>
                                    <th>Ciudad</th>
                                    <th>Provincia</th>
                                    <th>Teléfono</th>
                                    <th>Correo electrónico</th>
                                    <th>Foto</th>
                                </tr>
                            </thead>
                            <tbody>
                                {cliente &&
                                    cliente.map((client) => (
                                        <tr key={client.clienteId}>
                                            <td>{client.nombre}</td>
                                            <td>{client.apellido}</td>
                                            <td>{client.cedula}</td>
                                            <td>{client.direccion ?? "null"}</td>
                                            <td>{client.sector ?? "null"}</td>
                                            <td>{client.ciudad ?? "null"}</td>
                                            <td>{client.provincia ?? "null"}</td>
                                            <td>{client.telefono ?? "null"}</td>
                                            <td>{client.correoElectronico}</td>
                                            <td> <img src={client.rutaFoto ?? "/defaultImage.png"} className="image" /></td>
                                        </tr>
                                    ))}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <Modal
                title="Crear cliente"
                visible={isModalOpen}
                onCancel={() => {
                    setIsModalOpen(false);
                }}
                okText="Save"
                onOk={() => {
                    form.validateFields()
                        .then(values => {
                            Modal.info({
                                content: JSON.stringify(values)
                            })

                        })
                        .catch(error => {
                            message.error('Algunos campos no son válidos')
                        })
                }}
            >
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Nombre"
                        label="Nombre"
                        rules={[
                            {
                                required: true,
                                message: "El nombre es requerido"
                            }
                        ]
                        }>
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Apellido"
                        label="Apellido"
                        rules={[
                            {
                                required: true,
                                message: "El apellido es requerido"

                            }
                        ]
                        }>
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Cedula"
                        label="Cédula"
                        rules={[
                            {
                                required: true,
                                message: "La cédula es requerida"

                            }
                        ]
                        }>
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Dirección"
                        label="Dirección">
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Sector"
                        label="Sector">
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Ciudad"
                        label="Ciudad">
                        <Input />

                    </Form.Item>
                </Form >
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Provincia"
                        label="Provincia">
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Telefono"
                        label="Teléfono">
                        <Input />

                    </Form.Item>
                </Form>
                <Form layout='vertical' form={form}>
                    <Form.Item
                        name="Correo electrónico"
                        label="Correo electrónico">
                        <Input />

                    </Form.Item>
                </Form>
                {/* <Form>
                    <Form.Item label="Foto">
                        <Form.Item name="dragger" valuePropName="fileList" getValueFromEvent={normFile} noStyle>
                            <Upload.Dragger name="files" action="/upload.do">
                                <p className="ant-upload-drag-icon">
                                    <InboxOutlined />
                                </p>
                                <p className="ant-upload-text">Click or drag file to this area to upload</p>
                                <p className="ant-upload-hint">Support for a single or bulk upload.</p>
                            </Upload.Dragger>

                        </Form.Item>

                    </Form.Item>
                </Form> */}

            </Modal>
        </div>


    )

}

