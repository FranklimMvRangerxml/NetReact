import React, { Component } from 'react';
import { getUsuarios } from '../http/solicitud';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      usuarios: [],
      loading: true,
      error: null
    };
  }

  componentDidMount() {
    this.fetchUsuarios();
  }

  async fetchUsuarios() {
    try {
      const res = await getUsuarios();
      this.setState({ usuarios: res.data, loading: false });
    } catch (error) {
      console.log(error); // ← agrega esto para ver el error exacto
      this.setState({ error: error.message, loading: false });
    }
  }

  render() {
    const { usuarios, loading, error } = this.state;

    if (loading) return <p>Cargando usuarios...</p>;
    if (error) return <p style={{ color: 'red' }}>{error}</p>;

    return (
      <div>
        <span>Creado por : Franklim de jesus muñoz valverde .Net</span> <br />
        <span>Tecnologia React y .Net</span>
        <h1>Usuarios</h1>
        <table className="table table-striped table-bordered">
          <thead className="table-dark">
            <tr>
              <th>ID</th>
              <th>Cédula</th>
              <th>Nombre</th>
              <th>Correo</th>
              <th>Teléfono</th>
              <th>Rol</th>
              <th>Código</th>
              <th>Plan</th>
              <th>Sede</th>
              <th>Activo</th>
              <th>Creado</th>
            </tr>
          </thead>
          <tbody>
            {usuarios.map(u => (
              <tr key={u.id}>
                <td>{u.id}</td>
                <td>{u.cedula}</td>
                <td>{u.nombre}</td>
                <td>{u.correo}</td>
                <td>{u.telefono}</td>
                <td>{u.rol}</td>
                <td>{u.codigo}</td>
                <td>{u.plan?.nombre ?? '—'}</td>
                <td>{u.sede?.nombre ?? '—'}</td>
                <td>
                  <span className={`badge ${u.activo ? 'bg-success' : 'bg-danger'}`}>
                    {u.activo ? 'Sí' : 'No'}
                  </span>
                </td>
                <td>{new Date(u.creadoEn).toLocaleDateString('es-CO')}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}