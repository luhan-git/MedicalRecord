import React from 'react'
import { Link } from 'react-router-dom'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'

export function DataMedicamento({ data }) {
  return (
    <>
      {data.map(item => (
        <div
          key={item.id}
          className={`grid grid-cols-1 md:grid-cols-8 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl`}
        >
          <div className='md:hidden'>
            <h5 className='md:hidden text-white font-bold mb-2'>ID</h5>
            <p>{item.id}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>CODIGO</h5>
            <p>{item.codigo}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>
              NOMBRE GENERICO
            </h5>
            <p>{item.nombreGenerico}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>
              NOMBRE COMERCIAL
            </h5>
            <p>{item.nombreComercial}</p>
          </div>

          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>DOSIS</h5>
            <p>{item.dosis}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>INDICACIÓN</h5>
            <p>{item.indicacion}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>
              PRESENTACION
            </h5>
            <p>{item.idPresentacion}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ESTADO</h5>
            {item.estado === '0' && (
              <span className='py-1 px-2 bg-green-500/10 text-green-500 rounded-lg'>
                ACTIVO
              </span>
            )}
            {item.estado === '1' && (
              <span className='py-1 px-2 bg-yellow-500/10 text-yellow-500 rounded-lg'>
                PRUEBA
              </span>
            )}
            {item.estado === '2' && (
              <span className='py-1 px-2 bg-red-500/10 text-red-500 rounded-lg'>
                DESC
              </span>
            )}
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ACCIONES</h5>
            <Menu
              menuButton={
                <MenuButton className='flex items-center gap-x-2 bg-secondary-100 p-2 rounded-lg transition-colors'>
                  Acciones
                </MenuButton>
              }
              align='end'
              arrow
              arrowClassName='bg-secondary-100'
              transition
              menuClassName='bg-secondary-100 p-4'
            >
              <MenuItem className='p-0 hover:bg-transparent'>
                <Link
                  to='/perfil'
                  className='rounded-lg transition-colors text-gray-300 hover:bg-secondary-900 flex items-center gap-x-4 p-2 flex-1'
                >
                  Actualizar
                </Link>
              </MenuItem>
              <MenuItem className='p-0 hover:bg-transparent'>
                <Link
                  to='/perfil'
                  className='rounded-lg transition-colors text-gray-300 hover:bg-secondary-900 flex items-center gap-x-4 p-2 flex-1'
                >
                  Eliminar
                </Link>
              </MenuItem>
            </Menu>
          </div>
        </div>
      ))}
    </>
  )
}
