import { DataExamenLab } from '../../Components/DataExamenLab'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'
import { Suspense, useEffect, useState } from 'react'
export function ExamenLab() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)
  const headers = ['ID', 'NOMBRE', 'ABREVIATURA', 'ACCIONES']
  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/ExamenLab')
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
          <h1 className='text-2xl text-white my-10'>EXAMENES DE LABORATORIO</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataExamenLab data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
