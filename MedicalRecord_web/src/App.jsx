import { useState } from 'react'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
// Layouts
import { LayoutAuth } from './Layouts/LayoutAuth'
import { LayoutAdmin } from './Layouts/LayoutAdmin'
//Pages auth
import { Login } from './Pages/Auth/Login'
import { Register } from './Pages/Auth/Register'
import { ForgetPassword } from './Pages/Auth/ForgetPassword'
//Pages admin
import { Home } from './Pages/Admin/Home'
import { Profile } from './Pages/Admin/Profile'
import { Chat } from './Pages/Admin/Chat'
import { Error404 } from './Pages/Error404 '
import { Tickets } from './Pages/Admin/Tickets'
import { Paciente } from './Pages/Admin/Paciente'
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route index element={<Login />} />
        <Route path='/registro' element={<Register />} />
        <Route path='/olvide-password' element={<ForgetPassword />} />
        <Route path='/' element={<LayoutAdmin />}>
          <Route path='home' element={<Home />} />
          <Route path='paciente' element={<Paciente />} />
          <Route path='chat' element={<Chat />} />
          <Route path='tickets' element={<Tickets />} />
        </Route>
        <Route path='*' element={<Error404 />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
