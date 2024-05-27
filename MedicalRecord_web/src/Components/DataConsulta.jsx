import React from 'react'
import { Link } from 'react-router-dom'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'

export function DataConsulta({ data }) {
  return (
    <>
      {data.map(item => (
        <div
          key={item.id}
          className={`grid grid-cols-1 md:grid-cols-9 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl`}
        >
          <div className='md:hidden'>
            <h5 className='md:hidden text-white font-bold mb-2'>ID</h5>
            <p>{item.id}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>CODIGO</h5>
            <p>{item.numeroConsulta}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>PACIENTE</h5>
            <p>{item.paciente}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>MOTIVO</h5>
            <p>{item.motivo}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ENFERMEDAD</h5>
            <p>{item.enfermedadActual}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>DIAGNOSTICO</h5>
            <p>{item.diagnostico}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ATENDIÓ</h5>
            <p>{item.usuario}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>ASEGURADO</h5>
            <p>{item.asegurado}</p>
          </div>
          <div>
            <h5 className='md:hidden text-white font-bold mb-2'>FECHA</h5>
            <p>{item.fechaConsulta}</p>
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
                  Ver datos
                </Link>
              </MenuItem>
              <MenuItem className='p-0 hover:bg-transparent'>
                <Link
                  to='/perfil'
                  className='rounded-lg transition-colors text-gray-300 hover:bg-secondary-900 flex items-center gap-x-4 p-2 flex-1'
                >
                  Ver detalle
                </Link>
              </MenuItem>
            </Menu>
          </div>
        </div>
      ))}
    </>
  )
}
