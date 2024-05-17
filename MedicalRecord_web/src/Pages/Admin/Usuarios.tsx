import { useEffect, useState } from 'react'
import { Tables } from '../../Components/Tables.js'

export function Usuarios() {
  const [usuarios, setUsuarios] = useState([])
  const headers = ['ID', 'Nombre', 'Cargo', 'Session', 'Estado', 'Acciones']
  const obtenerDatos = () => {
    return new Promise((resolve, reject) => {
      fetch('https://localhost:7027/api/Usuarios')
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
  return <Tables data={usuarios} headers={headers}></Tables>
}
