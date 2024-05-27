import { DataLaboratorio } from '../../Components/DataLaboratorio'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'
import { Suspense, useEffect, useState } from 'react'
export function Laboratorio() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)
  const headers = ['ID', 'NOMBRE', 'ABREVIATURA', 'ACCIONES']
  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Laboratorio')
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
  return (
    <>
      <div>
        <div>
          <h1 className='text-2xl text-white my-10'>LABORATORIOS</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataLaboratorio data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
