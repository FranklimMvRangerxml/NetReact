import axios from 'axios';

const API = '/api/usuario';

export const getUsuarios = () => axios.get(API);

export const getUsuario = (id) => axios.get(`${API}/${id}`);

export const crearUsuario = (usuario) => axios.post(API, usuario);

export const loginUsuario = (datos) => axios.post(`${API}/login`, datos);

export const actualizarUsuario = (id, usuario) => axios.put(`${API}/${id}`, usuario);

export const eliminarUsuario = (id) => axios.delete(`${API}/${id}`);