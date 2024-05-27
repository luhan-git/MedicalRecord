import { HeaderTable } from '../../Components/HeaderTable'
import { DataCie } from '../../Components/DataCie'
import { Spinners } from '../../Components/Spinners'
import { Suspense, useEffect, useState } from 'react'
export function Cie() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)
  const headers = ['ID', 'CODIGO', 'ENFERMEDAD', 'ACCIONES']
  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Cie')
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
          <h1 className='text-2xl text-white my-10'>CIE 10 </h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataCie data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
