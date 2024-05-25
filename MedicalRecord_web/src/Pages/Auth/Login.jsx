import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { RiMailLine, RiLockLine, RiEyeLine, RiEyeOffLine } from 'react-icons/ri'

export function Login() {
  const [showPassword, setShowPassword] = useState(false)
  const [correo, setCorreo] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState(null)
  const navigate = useNavigate()
  const handleSubmit = async e => {
    e.preventDefault()
    setError(null)

    // Datos del formulario
    const formData = {
      correo,
      password
    }

    try {
      // Enviar solicitud POST a la API
      const response = await fetch('https://localhost:7027/api/Usuario/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
      })

      const data = await response.json()
      console.log(data)
      if (!response.ok) {
        throw new Error(data.message || 'Error al iniciar sesión')
      }
      // // Guardar el token en localStorage
      // localStorage.setItem('token', data.token)

      navigate('/home')
      console.log('Inicio de sesión exitoso:', data)
    } catch (error) {
      setError(error.message)
    }
  }

  return (
    <div className='min-h-screen flex items-center justify-center p-4'>
      <div className='bg-secondary-100 p-8 rounded-xl shadow-2xl w-auto lg:w-[450px]'>
        <h1 className='text-3xl text-center uppercase font-bold tracking-[5px] text-white mb-8'>
          Iniciar <span className='text-primary'>sesión</span>
        </h1>
        <form className='mb-8' onSubmit={handleSubmit}>
          <button className='flex items-center justify-center py-3 px-4 gap-4 bg-secondary-900 w-full rounded-full mb-8 text-gray-100'>
            <img
              src='https://rotulosmatesanz.com/wp-content/uploads/2017/09/2000px-Google_G_Logo.svg_.png'
              className='w-4 h-4'
              alt='Google logo'
            />
            Ingresa con google
          </button>
          <div className='relative mb-4'>
            <RiMailLine className='absolute top-1/2 -translate-y-1/2 left-2 text-primary' />
            <input
              type='emails'
              className='py-3 pl-8 pr-4 bg-secondary-900 w-full outline-none rounded-lg'
              placeholder='Correo electrónico'
              value={correo}
              onChange={e => setCorreo(e.target.value)}
              required
            />
          </div>
          <div className='relative mb-8'>
            <RiLockLine className='absolute top-1/2 -translate-y-1/2 left-2 text-primary' />
            <input
              type={showPassword ? 'text' : 'password'}
              className='py-3 px-8 bg-secondary-900 w-full outline-none rounded-lg'
              placeholder='Contraseña'
              value={password}
              onChange={e => setPassword(e.target.value)}
              required
            />
            {showPassword ? (
              <RiEyeOffLine
                onClick={() => setShowPassword(!showPassword)}
                className='absolute top-1/2 -translate-y-1/2 right-2 hover:cursor-pointer text-primary'
              />
            ) : (
              <RiEyeLine
                onClick={() => setShowPassword(!showPassword)}
                className='absolute top-1/2 -translate-y-1/2 right-2 hover:cursor-pointer text-primary'
              />
            )}
          </div>
          {error && <p className='text-red-500 text-center mb-4'>{error}</p>}
          <div>
            <button
              type='submit'
              className='bg-primary text-black uppercase font-bold text-sm w-full py-3 px-4 rounded-lg'
            >
              Ingresar
            </button>
          </div>
        </form>
        <div className='flex flex-col items-center gap-4'>
          <Link
            to='/olvide-password'
            className='hover:text-primary transition-colors'
          >
            ¿Olvidaste tu contraseña?
          </Link>
          <span className='flex items-center gap-2'>
            ¿No tienes cuenta?{' '}
            <Link
              to='/registro'
              className='text-primary hover:text-gray-100 transition-colors'
            >
              Regístrate
            </Link>
          </span>
        </div>
      </div>
    </div>
  )
}
