import React, { useState } from 'react'
import { Link } from 'react-router-dom'
// Icons
import {
  RiBarChart2Line,
  RiEarthLine,
  RiCustomerService2Line,
  RiCalendarTodoLine,
  RiLogoutCircleRLine,
  RiArrowRightSLine,
  RiMenu3Line,
  RiCloseLine
} from 'react-icons/ri'

export function Sidebar() {
  const [showMenu, setShowMenu] = useState(false)
  const [showSubmenuMantenimiento, setShowSubmenuMantenimiento] =
    useState(false)
  const [showSubmenuControl, setShowSubmenuControl] = useState(false)
  return (
    <>
      <div
        className={`xl:h-[100vh] overflow-y-scroll fixed xl:static w-[80%] md:w-[40%] lg:w-[30%] xl:w-auto h-full top-0 bg-secondary-100 p-4 flex flex-col justify-between z-50 ${
          showMenu ? 'left-0' : '-left-full'
        } transition-all`}
      >
        <div>
          <h1 className='text-center text-2xl font-bold text-white mb-10'>
            Oftalmología<span className='text-primary text-4xl'>.</span>
          </h1>
          <ul>
            <li>
              <Link
                to='/'
                className='flex items-center gap-4 py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
              >
                <RiBarChart2Line className='text-primary' /> Inicio
              </Link>
            </li>
            <li>
              <button
                onClick={() => setShowSubmenuControl(!showSubmenuControl)}
                className='w-full flex items-center justify-between py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
              >
                <span className='flex items-center gap-4'>
                  <RiEarthLine className='text-primary' /> Control
                </span>
                <RiArrowRightSLine
                  className={`mt-1 ${
                    showSubmenuControl && 'rotate-90'
                  } transition-all`}
                />
              </button>
              <ul
                className={` ${
                  showSubmenuControl ? 'h-[160px]' : 'h-0'
                } overflow-y-hidden transition-all`}
              >
                <li>
                  <Link
                    to='/Paciente'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Pacientes
                  </Link>
                </li>
                <li>
                  <Link
                    to='/consulta'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Consultas
                  </Link>
                </li>
                <li>
                  <Link
                    to='/Cita'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-gray-500 before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Citas
                  </Link>
                </li>
                <li>
                  <Link
                    to='/MedidaLente'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-gray-500 before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Medida de lentes
                  </Link>
                </li>
              </ul>
            </li>
            <li>
              <button
                onClick={() =>
                  setShowSubmenuMantenimiento(!showSubmenuMantenimiento)
                }
                className='w-full flex items-center justify-between py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
              >
                <span className='flex items-center gap-4'>
                  <RiEarthLine className='text-primary' /> Mantenimiento
                </span>
                <RiArrowRightSLine
                  className={`mt-1 ${
                    showSubmenuMantenimiento && 'rotate-90'
                  } transition-all`}
                />
              </button>
              <ul
                className={` ${
                  showSubmenuMantenimiento ? 'h-[25rem]' : 'h-0'
                } overflow-y-hidden transition-all`}
              >
                <li>
                  <Link
                    to='/usuario'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Administrativos
                  </Link>
                </li>
                <li>
                  <Link
                    to='/alergia'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Alergias
                  </Link>
                </li>
                <li>
                  <Link
                    to='/cie'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-gray-500 before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    CIE10
                  </Link>
                </li>
                <li>
                  <Link
                    to='/ciaseguro'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Compañias de Seguros
                  </Link>
                </li>
                <li>
                  <Link
                    to='/examenLab'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-gray-500 before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Examenes de Laboratorio
                  </Link>
                </li>
                <li>
                  <Link
                    to='/laboratorio'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-gray-500 before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Laboratorios
                  </Link>
                </li>
                <li>
                  <Link
                    to='/medicamento'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Medicamentos
                  </Link>
                </li>
                <li>
                  <Link
                    to='/Ocupacion'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Ocupaciones
                  </Link>
                </li>
                <li>
                  <Link
                    to='/Procedimiento'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Procedimientos Especiales
                  </Link>
                </li>
                <li>
                  <Link
                    to='/directorio'
                    className='py-2 px-4 border-l border-gray-500 ml-6 block relative before:w-3 before:h-3 before:absolute before:bg-primary before:rounded-full before:-left-[6.5px] before:top-1/2 before:-translate-y-1/2 before:border-4 before:border-secondary-100 hover:text-white transition-colors'
                  >
                    Directorio Teléfonico
                  </Link>
                </li>
              </ul>
            </li>
            <li>
              <Link
                to='/Reporte'
                className='flex items-center gap-4 py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
              >
                <RiCustomerService2Line className='text-primary' /> Reportes
              </Link>
            </li>
            <li>
              <Link
                to='/Utilitario'
                className='flex items-center gap-4 py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
              >
                <RiCalendarTodoLine className='text-primary' /> Utilitarios
              </Link>
            </li>
          </ul>
        </div>
        <nav>
          <Link
            to='/Usuario/CerrarSesion'
            className='flex items-center gap-4 py-2 px-4 rounded-lg hover:bg-secondary-900 transition-colors'
          >
            <RiLogoutCircleRLine className='text-primary' /> Cerrar sesión
          </Link>
        </nav>
      </div>
      <button
        onClick={() => setShowMenu(!showMenu)}
        className='xl:hidden fixed bottom-4 right-4 bg-primary text-black p-3 rounded-full z-50'
      >
        {showMenu ? <RiCloseLine /> : <RiMenu3Line />}
      </button>
    </>
  )
}
