import { Suspense, useEffect, useState } from 'react'
import { DataCiaSeguro } from '../../Components/DataCiaSeguro'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'

export function CiaSeguro() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)

  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/CiaSeguro')
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
          <h1 className='text-2xl text-white my-10'>Compañias de seguros</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={headers.length} />}>
            {data && <DataCiaSeguro data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
