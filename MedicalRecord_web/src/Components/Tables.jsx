import React from 'react'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'
import { Link } from 'react-router-dom'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'

export function Tables(props) {
  const { headers, data } = props
  return (
    <>
      <div>
        <h1 className='text-2xl text-white my-10'>Listado de Medicos</h1>
      </div>
      <div className='bg-secondary-100 p-8 rounded-xl'>
        <div className='hidden md:grid grid-cols-1 md:grid-cols-6 gap-4 mb-10 p-4'>
          {props.headers.map((item, index) => (
            <h5 key={index}>{item}</h5>
          ))}
        </div>
        {props.data.map(item => (
          <div
            key={item.idMedico}
            className='grid grid-cols-1 md:grid-cols-6 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl'
          >
            <div>
              <span>#{item.idMedico}</span>
            </div>
            <div>
              <p>{item.nombreMed}</p>
            </div>
            <div>
              <span>{item.espeMed}</span>
            </div>
            <div>
              <span>{item.nroCmed}</span>
            </div>
            <div>
              <span
                className={
                  item.estado
                    ? 'bg-green-500/10 text-green-500 py-1 px-2 rounded-lg'
                    : 'bg-red-500/10 text-red-500 py-1 px-2 rounded-lg'
                }
              >
                {item.estado ? 'Activo' : 'Inactivo'}
              </span>
            </div>
            <div>
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
                    Editar
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
      </div>
    </>
  )
}
