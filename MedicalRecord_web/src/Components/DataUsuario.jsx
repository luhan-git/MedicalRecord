import React from 'react'
import { Link } from 'react-router-dom'
import { RiArrowLeftSLine, RiArrowRightSLine } from 'react-icons/ri'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'

export function DataUsuario({ data }) {
  return (
    <>
      {data.map(item => (
        <div
          key={item.id}
          className={`grid grid-cols-1 md:grid-cols-6 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl`}
        >
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ID</h5>
            <p>{item.id}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>NOMBRE</h5>
            <p>{item.nombre}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>CORREO</h5>
            <p>{item.correo}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ROLL</h5>
            <p>{item.rol}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ACTIVO</h5>
            {item.activo ? (
              <span className='py-1 px-2 bg-green-500/10 text-green-500 rounded-lg'>
                Activo
              </span>
            ) : (
              <span className='py-1 px-2 bg-yellow-500/10 text-yellow-500 rounded-lg'>
                No Actvo
              </span>
            )}
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>Acciones</h5>
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
                  Ver detalle
                </Link>
              </MenuItem>
              <MenuItem className='p-0 hover:bg-transparent'>
                <Link
                  to='/perfil'
                  className='rounded-lg transition-colors text-gray-300 hover:bg-secondary-900 flex items-center gap-x-4 p-2 flex-1'
                >
                  Registrar Consulta
                </Link>
              </MenuItem>
            </Menu>
          </div>
        </div>
      ))}
    </>
  )
}
