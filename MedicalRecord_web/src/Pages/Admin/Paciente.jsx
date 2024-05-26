import React, { Suspense, useState, useEffect } from 'react'
import { HeaderTable } from '../../Components/HeaderTable'
import { DataPaciente } from '../../Components/DataPaciente'
import { Spinners } from '../../Components/Spinners'

export function Paciente() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)

  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Paciente')
      if (!response.ok) {
        throw new Error('Error al obtener los datos')
      }
      const data = await response.json()
      setData(data.resultado)
    } catch (error) {
      console.error(error)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    fetchDataAsync()
  }, [])

  const headers = [
    'ID',
    'NOMBRE',
    'DOCUMENTO',
    'EDAD',
    'CELULAR',
    'ASEGURADO',
    'CONDICIÓN',
    'ACCIONES'
  ]

  return (
    <>
      <div>
        <div>
          <h1 className='text-2xl text-white my-10'>Pacientes</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataPaciente data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
