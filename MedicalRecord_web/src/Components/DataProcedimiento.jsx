import React from 'react'
import { Link } from 'react-router-dom'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'

export function DataProcedimiento({ data }) {
  return (
    <>
      {data.map(item => (
        <div
          key={item.id}
          className={`grid grid-cols-1 md:grid-cols-4 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl`}
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
            <h5 className='md:hidden text-white font-bold mb-2'>ABREVIATURA</h5>
            <p>{item.abreviatura}</p>
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
