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
import { Usuarios } from './Pages/Admin/Usuarios'
import { Alergia } from './Pages/Admin/Alergia'
import { CiaSeguro } from './Pages/Admin/CiaSeguro'
import { Consulta } from './Pages/Admin/Consulta'
import { Directorio } from './Pages/Admin/Directorio'
import { Medicamento } from './Pages/Admin/Medicamento'
import { Ocupacion } from './Pages/Admin/Ocupacion'
import { Paciente } from './Pages/Admin/Paciente'
import { Procedimiento } from './Pages/Admin/Procedimiento'
import { Cie } from './Pages/Admin/Cie'
import { ExamenLab } from './Pages/Admin/ExamenLab'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/registro' element={<Register />} />
        <Route path='/olvide-password' element={<ForgetPassword />} />
        <Route path='/' element={<LayoutAdmin />}>
          <Route index element={<Home />} />
          <Route path='home' element={<Home />} />
          <Route path='usuario' element={<Usuarios />} />
          <Route path='alergia' element={<Alergia />} />
          <Route path='cie' element={<Cie></Cie>}></Route>
          <Route path='examenLab' element={<ExamenLab />} />
          <Route path='ciaseguro' element={<CiaSeguro />} />
          <Route path='consulta' element={<Consulta />} />
          <Route path='directorio' element={<Directorio />} />
          <Route path='medicamento' element={<Medicamento />} />
          <Route path='ocupacion' element={<Ocupacion />} />
          <Route path='paciente' element={<Paciente />} />
          <Route path='procedimiento' element={<Procedimiento />} />
          <Route path='chat' element={<Chat />} />
          <Route path='tickets' element={<Tickets />} />
        </Route>
        <Route path='*' element={<Error404 />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
