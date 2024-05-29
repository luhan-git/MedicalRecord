import {
  Dialog,
  DialogPanel,
  DialogTitle,
  Transition,
  TransitionChild
} from '@headlessui/react'

export function DialogPaciente({ isOpen, close }) {
  return (
    <Transition appear show={isOpen}>
      <Dialog
        as='div'
        className='relative z-10 focus:outline-none'
        onClose={close}
        __demoMode
      >
        <div className='fixed inset-0 z-10 w-screen '>
          <div className='flex min-h-full items-center justify-center p-4'>
            <TransitionChild
              enter='ease-out duration-300'
              enterFrom='opacity-0 transform-[scale(95%)]'
              enterTo='opacity-100 transform-[scale(100%)]'
              leave='ease-in duration-200'
              leaveFrom='opacity-100 transform-[scale(100%)]'
              leaveTo='opacity-0 transform-[scale(95%)]'
            >
              <DialogPanel className='relative w-80 h-full  max-w-md rounded-xl bg-white/5 p-6 backdrop-blur-2xl'>
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
                <p className='mt-2 text-sm/6 text-white/50'>
                  Your payment has been successfully submitted. We’ve sent you
                  an email with all of the details of your order. Lorem ipsum
                  dolor, sit amet consectetur adipisicing elit. Sapiente,
                  consequuntur esse! Obcaecati veniam inventore laudantium dolor
                  dignissimos recusandae! Veniam doloribus in eum? Omnis iste
                  perferendis aspernatur minima nulla temporibus eius? Lorem
                  ipsum dolor sit amet consectetur adipisicing elit. Vel odio et
                  quis tempora ipsa beatae distinctio velit laborum atque
                  reprehenderit. Est nihil ipsa maxime molestias, consequatur
                  neque quas esse corrupti? Lorem ipsum dolor sit amet
                  consectetur adipisicing elit. Vitae tempore vel cumque,
                  consequatur officia quibusdam aliquam dolor pariatur cum
                  recusandae impedit magnam autem harum enim ex! Magni ipsa quae
                  neque.
                </p>
                <div className='mt-4'></div>
              </DialogPanel>
            </TransitionChild>
          </div>
        </div>
      </Dialog>
    </Transition>
  )
}
