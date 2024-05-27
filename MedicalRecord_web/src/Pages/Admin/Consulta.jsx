import { Suspense, useEffect, useState } from 'react'
import { DataConsulta } from '../../Components/DataConsulta'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'

export function Consulta() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)

  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Consulta')
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
    'CODIGO',
    'PACIENTE',
    'MOTIVO',
    'ENFERMEDAD',
    'DIAGNOSTICO',
    'ATENDIÓ',
    'ASEGURADO',
    'FECHA',
    'ACCIONES',
  ]

  return (
    <>
      <div>
        <div>
          <h1 className='text-2xl text-white my-10'>Consultas</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataConsulta data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
