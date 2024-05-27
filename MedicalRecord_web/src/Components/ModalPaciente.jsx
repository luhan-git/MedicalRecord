import React from 'react'

export function ModalPaciente() {
  const [showModal, setShowModal] = React.useState(false)
  return (
    <>
      <button
        className='bg-pink-500 text-white active:bg-pink-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
        type='button'
        onClick={() => setShowModal(true)}
      >
        Open large modal
      </button>
      {showModal ? (
        <>
          <div className='justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none'>
            <div className='relative w-auto my-6 mx-auto max-w-6xl'>
              {/*content*/}
              <div className='border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none'>
                {/*header*/}
                <div className='flex items-start justify-between p-5 border-b border-solid border-blueGray-200 rounded-t'>
                  <h3 className='text-3xl font-semibold'>
                    Registro de paciente
                  </h3>
                  <button
                    className='p-1 ml-auto bg-transparent border-0 text-black opacity-5 float-right text-3xl leading-none font-semibold outline-none focus:outline-none'
                    onClick={() => setShowModal(false)}
                  >
                    <span className='bg-transparent text-black opacity-5 h-6 w-6 text-2xl block outline-none focus:outline-none'>
                      ×
                    </span>
                  </button>
                </div>
                {/*body*/}
                <div className='relative p-6 flex-auto'>
                  <div className='mb-4'>
                    <label className='block text-sm font-medium text-gray-700'>
                      Nombres
                    </label>
                    <input
                      type='text'
                      className='mt-1 p-2 w-full border border-gray-300 rounded-md'
                      placeholder='Nombre'
                    />
                  </div>
                  <div className='mb-4'>
                    <label className='block text-sm font-medium text-gray-700'>
                      Apellido Paterno
                    </label>
                    <input
                      type='text'
                      className='mt-1 p-2 w-full border border-gray-300 rounded-md'
                      placeholder='Apellido'
                    />
                  </div>
                  <div className='mb-4'>
                    <label className='block text-sm font-medium text-gray-700'>
                      Apellido Materno
                    </label>
                    <input
                      type='text'
                      className='mt-1 p-2 w-full border border-gray-300 rounded-md'
                      placeholder='Apellido'
                    />
                  </div>
                </div>
                {/*footer*/}
                <div className='flex items-center justify-end p-6 border-t border-solid border-blueGray-200 rounded-b'>
                  <button
                    className='text-red-500 background-transparent font-bold uppercase px-6 py-2 text-sm outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
                    type='button'
                    onClick={() => setShowModal(false)}
                  >
                    Close
                  </button>
                  <button
                    className='bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
                    type='button'
                    onClick={() => setShowModal(false)}
                  >
                    Save Changes
                  </button>
                </div>
              </div>
            </div>
          </div>
          <div className='opacity-25 fixed inset-0 z-40 bg-black'></div>
        </>
      ) : null}
    </>
  )
}
