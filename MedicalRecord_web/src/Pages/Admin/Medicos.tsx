import { useEffect, useState } from 'react'
import { Tables } from '../../Components/Tables.jsx'

export function Medicos() {
  const [medicos, setMedicos] = useState([])
  const headers = [
    'ID',
    'Nombre',
    'Especialidad',
    'NumeroCmed',
    'Estado',
    'Acciones'
  ]
  const obtenerDatos = () => {
    return new Promise((resolve, reject) => {
      fetch('https://localhost:7027/api/Medicos')
        .then(response => {
          if (response.ok) {
            return response.json()
          } else {
            throw new Error('Error al obtener los datos')
          }
        })
        .then(data => {
          setMedicos(data.resultado)
          resolve()
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
  return <Tables data={medicos} headers={headers}></Tables>
}
