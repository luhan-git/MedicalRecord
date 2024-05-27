import { Suspense, useEffect, useState } from 'react'
import { DataProcedimiento } from '../../Components/DataProcedimiento'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'

export function Procedimiento() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)

  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Procedimiento')
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

  const headers = ['ID', 'NOMBRE', 'ABREVIATURA', 'ACCIONES']

  return (
    <>
      <div>
        <div>
          <h1 className='text-2xl text-white my-10'>PROCEDIMIENTO</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataProcedimiento data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
