import { Suspense, useEffect, useState } from 'react'
import { DataUsuario } from '../../Components/DataUsuario'
import { HeaderTable } from '../../Components/HeaderTable'
import { Spinners } from '../../Components/Spinners'

export function Usuarios() {
  const [data, setData] = useState(null)
  const [loading, setLoading] = useState(true)

  const fetchDataAsync = async () => {
    try {
      const response = await fetch('https://localhost:7027/api/Usuario')
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
  const headers = ['ID', 'Nombre', 'Correo', 'ROL', 'Estado', 'Acciones']

  return (
    <>
      <div>
        <div>
          <h1 className='text-2xl text-white my-10'>Usuarios</h1>
        </div>
        <div className='bg-secondary-100 p-8 rounded-xl'>
          <HeaderTable data={headers} />
          {loading && <Spinners number={headers.length} />}
          <Suspense fallback={<Spinners number={6} />}>
            {data && <DataUsuario data={data} />}
          </Suspense>
        </div>
      </div>
    </>
  )
}
