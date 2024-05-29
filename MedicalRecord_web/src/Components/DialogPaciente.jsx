import {
  Dialog,
  DialogPanel,
  DialogTitle,
  Transition,
  TransitionChild
} from '@headlessui/react'
import { RiUserLine } from 'react-icons/ri'
export function DialogPaciente({ isOpen, close }) {
  return (
    <Transition appear show={isOpen}>
      <Dialog
        as='div'
        className='relative z-10 focus:outline-none'
        onClose={close}
        __demoMode
      >
        <div className='fixed inset-0 z-10 w-screen'>
          <div className='flex min-h-full items-center justify-center md:justify-end  md:px-9'>
            <TransitionChild
              enter='ease-out duration-300'
              enterFrom='opacity-0 transform-[scale(95%)]'
              enterTo='opacity-100 transform-[scale(100%)]'
              leave='ease-in duration-200'
              leaveFrom='opacity-100 transform-[scale(100%)]'
              leaveTo='opacity-0 transform-[scale(95%)]'
            >
              <DialogPanel className='relative w-80 h-full max-w-md md:max-w-full md:w-[68rem] rounded-xl bg-white/5 p-6 backdrop-blur-2xl'>
                <button
                  className='absolute top-2 right-2 text-slate-500  p-1 focus:outline-none hover:text-white'
                  onClick={close}
                >
                  ✕
                </button>
                <DialogTitle
                  as='h3'
                  className='text-base/7 font-medium text-white'
                >
                  Datos - Antecedentes
                </DialogTitle>
                <form>
                  <div className='px-4 py-8 flex flex-col md:flex-row md:items-center md:justify-center gap-8'>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='#Paciente'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Fecha Registro'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Edad'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Sexo'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Asegurado'
                      />
                    </div>
                  </div>
                  <div className='px-4 py-8 flex flex-col md:flex-row md:items-center md:justify-center gap-8'>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Nombre(s)'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Apellido paterno'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Apellido materno'
                      />
                    </div>
                  </div>
                  <div className='px-4 py-8 flex flex-col md:flex-row md:items-center md:justify-center gap-8'>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Documento'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='N° Documento'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Fecha nacimiento'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Estado Civil'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='G Sanguineo'
                      />
                    </div>
                  </div>
                  <div className='px-4 py-8 flex flex-col md:flex-row md:items-center md:justify-center gap-8'>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Correo'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Nacionalidad'
                      />
                    </div>
                    <div className='w-full relative'>
                      <RiUserLine className='text-gray-300 absolute top-1/2 -translate-y-1/2 left-4' />
                      <input
                        className='w-full bg-gray-100 py-2 pl-10 pr-4 rounded-lg outline-none'
                        placeholder='Lugar de nacimiento'
                      />
                    </div>
                  </div>
                </form>
              </DialogPanel>
            </TransitionChild>
          </div>
        </div>
      </Dialog>
    </Transition>
  )
}
