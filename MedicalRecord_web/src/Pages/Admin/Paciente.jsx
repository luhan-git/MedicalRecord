import { TablePaciente } from '../../Components/TablePaciente'
import { useState, useEffect } from 'react'

export function Paciente() {
  const [pacientes, setPacientes] = useState([])
  const headers = [
    'ID',
    'Nombre',
    'Documento',
    'Edad',
    'Celuar',
    'Asegurado',
    'Condición',
    'Acciones'
  ]
  const obtenerDatos = async () => {
    const response = await fetch('https://localhost:7027/api/Paciente')
    const data = await response.json()
    setPacientes(data.resultado)
    console.log(data.resultado)
  }
  useEffect(() => {
    obtenerDatos()
  }, [])

  return <TablePaciente headers={headers} data={pacientes}></TablePaciente>
}
