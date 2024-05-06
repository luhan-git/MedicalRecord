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
  const obtenerDatos = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Medico')
      if (response.ok) {
        const data = await response.json()
        console.log(data)
        setMedicos(data.resultado)
      }
    } catch (error) {
      console.log(error)
    }
  }
  useEffect(() => {
    obtenerDatos()
  }, [])
  return <Tables data={medicos} headers={headers}></Tables>
}
