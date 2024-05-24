import React from 'react'
import { Link } from 'react-router-dom'
import { RiArrowLeftSLine, RiArrowRightSLine } from 'react-icons/ri'
import { Menu, MenuItem, MenuButton } from '@szhsin/react-menu'
import '@szhsin/react-menu/dist/index.css'
import '@szhsin/react-menu/dist/transitions/slide.css'

export function TablePaciente(props) {
  return (
    <div>
      <div>
        <h1 className='text-2xl text-white my-10'>Paciente</h1>
      </div>
      <div className='bg-secondary-100 p-8 rounded-xl'>
        <div className='hidden md:grid grid-cols-1 md:grid-cols-8 gap-4 mb-10 p-4'>
          {props.headers.map((header, index) => (
            <h5 key={index}>{header}</h5>
          ))}
        </div>
        {props.data.map(paciente => (
          <div
            key={paciente.id}
            className='grid grid-cols-1 md:grid-cols-8 gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl'
          >
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>ID</h5>
              <p>{paciente.id}</p>
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>NOMBRE</h5>
              <p>{paciente.nombres}</p>
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>DOCUMENTO</h5>
              <p>{paciente.numeroDocumento}</p>
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>EDAD</h5>
              <p>{paciente.edad}</p>
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>CELULAR</h5>
              <p>{paciente.celular}</p>
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>ASEGURADO</h5>
              {paciente.asegurado ? (
                <span className='py-1 px-2 bg-green-500/10 text-green-500 rounded-lg'>
                  Si
                </span>
              ) : (
                <span className='py-1 px-2 bg-yellow-500/10 text-yellow-500 rounded-lg'>
                  No
                </span>
              )}
            </div>
            <div>
              <h5 className='md:hidden text-white font-bold mb-2'>CONDICIÓN</h5>
              {paciente.condicion === '0' && (
                <span className='py-1 px-2 bg-green-500/10 text-green-500 rounded-lg'>
                  Regular
                </span>
              )}
              {paciente.condicion === '1' && (
                <span className='py-1 px-2 bg-yellow-500/10 text-yellow-500 rounded-lg'>
                  Retirado
                </span>
              )}
              {paciente.condicion === '2' && (
                <span className='py-1 px-2 bg-red-500/10 text-red-500 rounded-lg'>
                  Fallecido
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
      </div>
    </div>
  )
}
