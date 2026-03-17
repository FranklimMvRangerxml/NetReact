export const endpoints = [
    {
        ruta: "login Post",
        link: "https://localhost:7237/api/Auth/login",
        body: {
            correo: "f5extuniversal@gmail.com",
            contrasenaHash: "Millonario2090**"
        }
    },
    {
        ruta: "Crear usuario Post",
        link: "https://localhost:7237/api/usuario",
        body: {
            cedula: "123456789",
            nombre: "Juan Pérez",
            correo: "juan@correo.com",
            telefono: "3001234567",
            contrasenaHash: "123456",
            rol: "empleado",
            codigo: "USR001",
            planId: 1,
            sedeId: 1,
            activo: false
        }
    },
    {
        ruta: "Sede Post",
        link: "https://localhost:7237/api/sede",
        body: {
            usuarioSede: 2,
            img: "https://ejemplo.com/imagen.jpg",
            nombre: "Sede Secundaria",
            ubicacion: "Calle 1d # 52-125, Cali",
            estado: "activo"
        }
    },
    {
        ruta: "Plan Post",
        link: " https://localhost:7237/api/plan",
        body: {
            "Nombre": "Sede Secundaria",
            "MaxDays": 15
        }
    }
];