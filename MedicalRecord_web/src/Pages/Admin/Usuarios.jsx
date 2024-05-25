import { useEffect, useState } from 'react'
import { TableUsuario } from '../../Components/TabeUsuario'

export function Usuarios() {
  const [usuarios, setUsuarios] = useState([])
  const headers = ['ID', 'Nombre', 'Correo', 'ROL', 'Estado', 'Acciones']
  const obtenerDatos = () => {
    return new Promise((resolve, reject) => {
      fetch('https://localhost:7027/api/Usuario')
        .then(response => {
          if (response.ok) {
            return response.json()
          } else {
            throw new Error('Error al obtener los datos')
          }
        })
        .then(data => {
          setUsuarios(data.resultado)
          resolve(-1)
        })
        .catch(error => {
          console.error(error)
          reject(error)
        })
    })
  }

  useEffect(() => {
    obtenerDatos()
  }, [])
  return <TableUsuario data={usuarios} headers={headers}></TableUsuario>
}
