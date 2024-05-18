-- USUARIOS
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Ana Mart�nez', 'ana@example.com', 'ana123', 'M�dico', 'Pediatr�a', '654321', TRUE);

INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, activo) 
VALUES ('Carlos Rodr�guez', 'carlos@example.com', 'carlos456', 'Enfermero', NULL, FALSE);

INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Laura Fern�ndez', 'laura@example.com', 'laura789', 'Administrativo', NULL, NULL, TRUE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Pablo S�nchez', 'pablo@example.com', 'pablo123', 'M�dico', 'Ginecolog�a', '987654', TRUE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, activo) 
VALUES ('Sof�a G�mez', 'sofia@example.com', 'sofia456', 'Enfermera', NULL, TRUE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Diego P�rez', 'diego@example.com', 'diego789', 'Administrativo', NULL, '234567', FALSE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Elena L�pez', 'elena@example.com', 'elena123', 'M�dico', 'Dermatolog�a', '876543', TRUE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, activo) 
VALUES ('Mario Torres', 'mario@example.com', 'mario456', 'Enfermero', NULL, TRUE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Luc�a Rodr�guez', 'lucia@example.com', 'lucia789', 'Administrativo', NULL, NULL, FALSE);
INSERT INTO Usuario (nombre, correo, clave, cargo, especialidad, nroColMedico, activo) 
VALUES ('Andr�s Mart�nez', 'andres@example.com', 'andres123', 'M�dico', 'Oftalmolog�a', '765432', TRUE);

-- LABORATORIO
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio Cl�nico Central', 'LCC');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Microbiolog�a', 'LM');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Patolog�a', 'LP');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Bioqu�mica', 'LBQ');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Gen�tica', 'LG');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Inmunolog�a', 'LI');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Histolog�a', 'LH');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Parasitolog�a', 'LPS');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Qu�mica', 'LQ');
INSERT INTO Laboratorio (nombre, abreviatura) VALUES ('Laboratorio de Farmacolog�a', 'LF');
-- PRESENTACIONES
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Tableta', 'Tab');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('C�psula', 'C�p');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Jarabe', 'Jar');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Suspensi�n', 'Sus');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Soluci�n', 'Sol');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Inyectable', 'Iny');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Crema', 'Cre');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Gel', 'Gel');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Aerosol', 'Aer');
INSERT INTO Presentacion (nombre, abreviatura) VALUES ('Supositorio', 'Sup');

-- CIE
INSERT INTO CIE (codigo, enfermedad) VALUES ('H25', 'Catarata senil');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H40', 'Glaucoma');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H53', 'Trastornos de la agudeza visual');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H15', 'Trastornos de la escler�tica y de la c�rnea');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H28', 'Catarata en enfermedades clasificadas en otra parte');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H10', 'Conjuntivitis');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H26', 'Otros trastornos del cristalino');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H33', 'Desprendimiento y desgarro de la retina');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H47', 'Trastornos del nervio �ptico y de las v�as �pticas');
INSERT INTO CIE (codigo, enfermedad) VALUES ('H02', 'Otros trastornos del p�rpado');

-- EXAMENES DE LABORATORIO
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Conteo de c�lulas sangu�neas', 'CSC');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Glucosa en sangre', 'Glu');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Hemoglobina A1c', 'HbA1c');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Perfil lip�dico', 'PL');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Prueba de coagulaci�n', 'PC');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Biomicroscop�a de l�mpara de hendidura', 'BLH');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Presi�n intraocular', 'PIO');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Gonioscopia', 'GON');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Prueba de Schirmer', 'PS');
INSERT INTO ExamenLaboratorio (nombre, abreviatura) VALUES ('Citolog�a de frotis ocular', 'CFO');

-- PROCEDIMIENTOS
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de catarata', 'CC');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de glaucoma', 'CG');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a refractiva', 'CR');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de p�rpados', 'CP');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de retina', 'CRet');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de v�as lagrimales', 'CVL');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de estrabismo', 'CE');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de c�rnea', 'CCo');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de segmento anterior', 'CSA');
INSERT INTO Procedimiento (nombre, abreviatura) VALUES ('Cirug�a de segmento posterior', 'CSP');

-- COMPA��AS DE SEGURO
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros Bol�var', 'SB');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros del Estado', 'SE');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Vida', 'SV');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Salud', 'SS');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Accidentes', 'SA');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Viaje', 'SVi');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Hogar', 'SH');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Autom�vil', 'SAu');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Responsabilidad Civil', 'SRC');
INSERT INTO CiaSeguro (nombre, abreviatura) VALUES ('Seguros de Incendio', 'SI');

-- DIRECTORIO
INSERT INTO Directorio (nombre, representante, telefono, celular, email, direccion, estado) 
VALUES 
('Laboratorio ABC', 'Dr. Juan P�rez', '01-2345678', '98765-4321', 'info@laboratorioabc.com', 'Av. Los Conquistadores 123, Lima', TRUE),
('Farmacia XYZ', 'Dra. Mar�a Gonz�lez', '01-3456789', '98765-4321', 'info@farmaciaxyz.com', 'Av. Larco 456, Miraflores, Lima', TRUE),
('Cl�nica Oftalmol�gica Vista Clara', 'Dr. Carlos Rodr�guez', '01-4567890', '98765-4321', 'info@vistaclaraclinic.com', 'Av. Arequipa 789, Lince, Lima', TRUE),
('Distribuidora de Lentes Visi�n', 'Sra. Laura D�az', '01-5678901', '98765-4321', 'info@visionlentes.com', 'Jr. Huancavelica 234, Lima', TRUE),
('Laboratorio de Pruebas Oculares Visi�n Integral', 'Dr. Luis Gonzales', '01-6789012', '98765-4321', 'info@visionintegral.com', 'Av. Tacna 345, Lima', TRUE),
('�ptica Central', 'Sr. Javier Flores', '01-7890123', '98765-4321', 'info@opticacentral.com', 'Av. Tacna 456, Lima', TRUE),
('Farmacia Oftalmol�gica Visual Farma', 'Dra. Ana Silva', '01-8901234', '98765-4321', 'info@visualfarma.com', 'Av. Abancay 567, Lima', TRUE),
('Centro de Cirug�a L�ser de la Vista', 'Dr. Eduardo P�rez', '01-9012345', '98765-4321', 'info@cirugialaser.com', 'Av. Pardo 678, Lima', TRUE),
('Distribuidora de Equipos M�dicos Oft�lmicos', 'Sr. Miguel S�nchez', '01-0123456', '98765-4321', 'info@equiposoftalmicos.com', 'Av. Garcilaso de la Vega 789, Lima', TRUE),
('Laboratorio de Investigaci�n Oftalmol�gica', 'Dr. Jos� Gonz�lez', '01-1234567', '98765-4321', 'info@investigacionoftalmo.com', 'Av. Petit Thouars 890, Lima', TRUE);

-- OCUPACIONES
INSERT INTO Ocupacion (nombre, detalle) VALUES ('M�dico oftalm�logo', 'M�dico');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Optometrista', NULL);
INSERT INTO Ocupacion (nombre, detalle) VALUES ('T�cnico en optometr�a', 'T�cnico');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Enfermero oftalmol�gico', 'Enfermero');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Recepcionista de consultorio oftalmol�gico', 'Recepcionista');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Asistente de investigaci�n oftalmol�gica', 'Asistente');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Farmac�utico', NULL);
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Administrador de cl�nica oftalmol�gica', 'Administrador');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Representante de ventas de equipos oftalmol�gicos', 'Representante');
INSERT INTO Ocupacion (nombre, detalle) VALUES ('Estudiante de medicina', 'Estudiante');

-- MEDICAMENTOS
INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('ABC123', 'OftaClear', 'Clorhidrato de X', 'A', '1 gota en el ojo afectado, 2 veces al d�a', 'Para el tratamiento del glaucoma', 1, 1);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('DEF456', 'VisioPlus', 'Latanoprost', 'A', '1 gota en el ojo afectado, una vez al d�a', 'Para reducir la presi�n intraocular', 2, 2);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('GHI789', 'LacriClear', 'L�grimas artificiales', 'A', 'Seg�n sea necesario', 'Para aliviar la sequedad ocular', 3, 3);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('JKL012', 'Oculinex', 'Sulfato de Neomicina', 'A', 'Aplicar una peque�a cantidad en el p�rpado afectado, 4 veces al d�a', 'Para tratar infecciones oculares', 4, 4);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('MNO345', 'OftaVit', 'Vitamina A', 'A', '1 c�psula al d�a', 'Suplemento vitam�nico para la salud ocular', 5, 5);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('PQR678', 'CiproClear', 'Ciprofloxacino', 'A', '2 gotas en el ojo afectado, cada 4 horas', 'Para tratar infecciones oculares bacterianas', 6, 6);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('STU901', 'OftaLub', 'Carboximetilcelulosa s�dica', 'A', 'Seg�n sea necesario', 'Para aliviar la sequedad ocular', 7, 7);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('VWX234', 'PredniClear', 'Prednisolona', 'A', '1 gota en el ojo afectado, 4 veces al d�a', 'Para reducir la inflamaci�n ocular', 8, 8);

INSERT INTO Medicamento (codigo, nombreComercial, nombreGenerico, estado, dosis, indicacion, idPresentacion, idLaboratorio) 
VALUES ('YZA567', 'Ocultrin', 'Cloruro de sodio', 'A', 'Seg�n sea necesario', 'Para lavado ocular', 9, 9);

-- DIABETES
INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes tipo 1', 'Se produce cuando el p�ncreas no produce suficiente insulina.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes tipo 2', 'Se produce cuando el cuerpo no puede usar la insulina de manera efectiva.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes gestacional', 'Se desarrolla durante el embarazo y puede desaparecer despu�s del parto.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes secundaria', 'Se produce como resultado de otra enfermedad o medicamento.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes monog�nica', 'Es causada por una mutaci�n en un solo gen.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes tipo 3', 'Propuesta para describir la enfermedad de Alzheimer como una forma de diabetes cerebral.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes tipo 1.5 (LADA)', 'Se refiere a una forma de diabetes autoinmune que se desarrolla en adultos.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes ins�pida', 'Es un trastorno que afecta la regulaci�n del agua en el cuerpo, no est� relacionada con la insulina.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes juvenil', 'T�rmino coloquial utilizado para referirse a la diabetes tipo 1.');

INSERT INTO Diabetes (tipo, detalle) 
VALUES ('Diabetes mody', 'Se refiere a un grupo heterog�neo de trastornos monog�nicos que afectan la secreci�n de insulina.');

-- ALERGIAS
INSERT INTO Alergia (nombre) VALUES ('Polen');
INSERT INTO Alergia (nombre) VALUES ('�caros del polvo');
INSERT INTO Alergia (nombre) VALUES ('Moho');
INSERT INTO Alergia (nombre) VALUES ('Caspa de animales');
INSERT INTO Alergia (nombre) VALUES ('Alimentos');

-- DEPARTAMENTOS
INSERT INTO departamento (departamento) VALUES ('Amazonas');
INSERT INTO departamento (departamento) VALUES ('�ncash');
INSERT INTO departamento (departamento) VALUES ('Apur�mac');
INSERT INTO departamento (departamento) VALUES ('Arequipa');
INSERT INTO departamento (departamento) VALUES ('Ayacucho');
INSERT INTO departamento (departamento) VALUES ('Cajamarca');
INSERT INTO departamento (departamento) VALUES ('Callao');
INSERT INTO departamento (departamento) VALUES ('Cusco');
INSERT INTO departamento (departamento) VALUES ('Huancavelica');
INSERT INTO departamento (departamento) VALUES ('Hu�nuco');
INSERT INTO departamento (departamento) VALUES ('Ica');
INSERT INTO departamento (departamento) VALUES ('Jun�n');
INSERT INTO departamento (departamento) VALUES ('La Libertad');
INSERT INTO departamento (departamento) VALUES ('Lambayeque');
INSERT INTO departamento (departamento) VALUES ('Lima');
INSERT INTO departamento (departamento) VALUES ('Loreto');
INSERT INTO departamento (departamento) VALUES ('Madre de Dios');
INSERT INTO departamento (departamento) VALUES ('Moquegua');
INSERT INTO departamento (departamento) VALUES ('Pasco');
INSERT INTO departamento (departamento) VALUES ('Piura');
INSERT INTO departamento (departamento) VALUES ('Puno');
INSERT INTO departamento (departamento) VALUES ('San Mart�n');
INSERT INTO departamento (departamento) VALUES ('Tacna');
INSERT INTO departamento (departamento) VALUES ('Tumbes');
INSERT INTO departamento (departamento) VALUES ('Ucayali');

-- PROVINCIAS
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Chachapoyas', 1);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Bagua', 1);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Bongar�', 1);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Condorcanqui', 1);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Utcubamba', 1);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Huaraz', 2);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Aija', 2);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Antonio Raymondi', 2);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Asunci�n', 2);
INSERT INTO provincia (provincia, idDepartamento) VALUES ('Bolognesi', 2);

-- DISTRITOS
INSERT INTO distrito (distrito, idProvincia) VALUES ('Chachapoyas', 1);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Asunci�n', 1);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Balsas', 1);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Cheto', 1);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Chiliquin', 1);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Huaraz', 6);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Cochabamba', 6);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Colcabamba', 6);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Huanchay', 6);
INSERT INTO distrito (distrito, idProvincia) VALUES ('Independencia', 6);

-- PARENTESCO
INSERT INTO Parentesco (valor) VALUES ('Padre');
INSERT INTO Parentesco (valor) VALUES ('Madre');
INSERT INTO Parentesco (valor) VALUES ('Hijo');
INSERT INTO Parentesco (valor) VALUES ('Hija');
INSERT INTO Parentesco (valor) VALUES ('Abuelo');
INSERT INTO Parentesco (valor) VALUES ('Abuela');
INSERT INTO Parentesco (valor) VALUES ('T�o');
INSERT INTO Parentesco (valor) VALUES ('T�a');
INSERT INTO Parentesco (valor) VALUES ('Primo');
INSERT INTO Parentesco (valor) VALUES ('Prima');
INSERT INTO Parentesco (valor) VALUES ('Sobrino');
INSERT INTO Parentesco (valor) VALUES ('Sobrina');
INSERT INTO Parentesco (valor) VALUES ('Hermano');
INSERT INTO Parentesco (valor) VALUES ('Hermana');
INSERT INTO Parentesco (valor) VALUES ('Cu�ado');
INSERT INTO Parentesco (valor) VALUES ('Cu�ada');
INSERT INTO Parentesco (valor) VALUES ('Yerno');
INSERT INTO Parentesco (valor) VALUES ('Nuera');
INSERT INTO Parentesco (valor) VALUES ('Suegro');
INSERT INTO Parentesco (valor) VALUES ('Suegra');
INSERT INTO Parentesco (valor) VALUES ('Padrino');
INSERT INTO Parentesco (valor) VALUES ('Madrina');

-- PACIENTE
INSERT INTO Paciente (condicion, aPaterno, aMaterno, nombres, tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo, estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular)
VALUES ('0', 'Garc�a', 'P�rez', 'Mar�a', '0', '12345678', '1990-05-15', '31', '1', '0', '0', '0', 15, 194, 1833, 'Av. Los Pinos 123', '01-2345678', '98765-4321');

INSERT INTO Paciente (condicion, aPaterno, aMaterno, nombres, tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo, estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular)
VALUES ('0', 'Mart�nez', 'G�mez', 'Juan', '0', '87654321', '1985-10-20', '36', '1', '1', '1', '0', 15, 194, 1833, 'Av. Los Pinos 456', '01-3456789', '98765-4321');

INSERT INTO Paciente (condicion, aPaterno, aMaterno, nombres, tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo, estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular)
VALUES ('0', 'Rodr�guez', 'L�pez', 'Luis', '0', '56781234', '1995-03-25', '26', '1', '2', '2', '0', 15, 194, 1833, 'Av. Los Pinos 789', '01-4567890', '98765-4321');

INSERT INTO Paciente (condicion, aPaterno, aMaterno, nombres, tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo, estadoCivil, grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular)
VALUES ('0', 'G�mez', 'Mart�nez', 'Ana', '0', '43218765', '2000-12-10', '21', '0', '3', '3', '0', 15, 194, 1833, 'Av. Los Pinos 234', '01-5678901', '98765-4321');

-- DETALLE ALERGIA
INSERT INTO DetalleAlergia (idPaciente, idAlergia) VALUES (1, 1);
INSERT INTO DetalleAlergia (idPaciente, idAlergia) VALUES (1, 2);
INSERT INTO DetalleAlergia (idPaciente, idAlergia) VALUES (2, 3);
INSERT INTO DetalleAlergia (idPaciente, idAlergia) VALUES (3, 4);
INSERT INTO DetalleAlergia (idPaciente, idAlergia) VALUES (4, 5);

-- CONSULTA
INSERT INTO Consulta (numeroConsulta, motivo, enfermedadActual, davsc, iavsc, davcc, iavcc, dpio, ipio, shimer, valorK, diagnostico, idCie, idUsuario, idPaciente) 
VALUES 
('C000001', 'Dolor ocular', 'El paciente se queja de dolor ocular agudo en el ojo derecho.', '20/20', '20/20', '20/20', '20/20', '12 mmHg', '12 mmHg', '5 mm', '45 D', 'Conjuntivitis aguda', 1, 1, 1),
('C000002', 'Visi�n borrosa', 'El paciente experimenta visi�n borrosa en ambos ojos desde hace una semana.', '20/30', '20/30', '20/20', '20/20', '14 mmHg', '14 mmHg', '8 mm', '40 D', 'Presbicia', 2, 2, 2),
('C000003', 'Ojo rojo', 'El ojo derecho del paciente presenta enrojecimiento y molestia al parpadear.', '20/20', '20/20', '20/20', '20/20', '16 mmHg', '16 mmHg', '6 mm', '42 D', 'Conjuntivitis al�rgica', 3, 3, 3),
('C000004', 'Picaz�n en los ojos', 'El paciente se queja de picaz�n severa en ambos ojos, especialmente por las ma�anas.', '20/25', '20/25', '20/20', '20/20', '13 mmHg', '13 mmHg', '7 mm', '41 D', 'Conjuntivitis cr�nica', 4, 4, 4),
('C000005', 'Ojo seco', 'El paciente reporta sequedad ocular y sensaci�n de cuerpo extra�o en el ojo izquierdo.', '20/20', '20/20', '20/20', '20/20', '15 mmHg', '15 mmHg', '6.5 mm', '44 D', 'Ojo seco cr�nico', 5, 5, 5);

-- DETALLE EXAMEN LABORATORIO
INSERT INTO DetalleExamen (idConsulta, idExamenLab, detalle, resultado, fechaResultado) 
VALUES 
(1, 1, 'Conteo de c�lulas sangu�neas', 'Gl�bulos blancos: 8000/�L, Gl�bulos rojos: 4.5 millones/�L', '2024-05-17 10:30:00'),
(2, 2, 'Glucosa en sangre', 'Glucosa: 120 mg/dL', '2024-05-18 11:45:00'),
(3, 3, 'Perfil lip�dico', 'Colesterol total: 180 mg/dL, HDL: 50 mg/dL, LDL: 100 mg/dL', '2024-05-19 09:15:00'),
(4, 4, 'Prueba de coagulaci�n', 'Tiempo de protrombina: 12 segundos', '2024-05-20 08:20:00'),
(5, 5, 'Biomicroscop�a de l�mpara de hendidura', 'Sin anomal�as significativas', '2024-05-21 14:00:00');

-- DETALLE PROCEDIMIENTO
INSERT INTO DetalleProcedimiento (idConsulta, idProcedimiento, detalle, indicacion, resultado, imagenes, directorio, fechaResultado) 
VALUES 
(1, 1, 'Cirug�a de cataratas en ojo derecho', 'Remover la catarata y colocar lente intraocular.', 'La cirug�a fue exitosa, paciente reporta mejora en la visi�n.', TRUE, '/directorio/imagenes/cirugia_cataratas', '2024-05-17 13:30:00'),
(2, 2, 'Angiograf�a con fluoresce�na', 'Inyectar fluoresce�na intravenosa para evaluar el flujo sangu�neo retiniano.', 'Angiograf�a muestra �reas de neovascularizaci�n retiniana.', TRUE, '/directorio/imagenes/angiografia_fluoresceina', '2024-05-18 14:45:00'),
(3, 3, 'Laserterapia retiniana', 'Aplicar l�ser focal para tratar la retinopat�a diab�tica.', 'Se observa regresi�n de los microaneurismas retinianos.', FALSE, NULL, '2024-05-19 11:20:00'),
(4, 4, 'Cirug�a de correcci�n de estrabismo', 'Ajustar los m�sculos oculares para corregir el desalineamiento de los ojos.', 'Se logr� una alineaci�n adecuada de los ojos.', TRUE, '/directorio/imagenes/cirugia_estrabismo', '2024-05-20 10:10:00'),
(5, 5, 'Trabeculectom�a', 'Crear una nueva v�a de drenaje para reducir la presi�n intraocular.', 'Se observa una disminuci�n significativa en la presi�n intraocular.', FALSE, NULL, '2024-05-21 09:00:00');

-- MEDIDA LENTE
INSERT INTO MedidaLente (idConsulta, ODSPHL, ODCYSL, ODAXIL, ODAV, OISPHL, OICYSL, OIAXIL, OIAV, PDL, OBSL, ODSPHC, ODCYSC, ODAXIC, OISPHC, OICYSC, OIAXIC, PDC, OBSC, preventiva) 
VALUES 
(1, '-2.50', '-0.75', '180', '20/20', '-2.25', '-1.00', '180', '20/20', '65', 'Esfera: -2.50, Cilindro: -0.75, Eje: 180, Agudeza visual: 20/20', '-2.25', '-1.00', '180', '-2.25', '-1.00', '180', '60', 'Esfera: -2.25, Cilindro: -1.00, Eje: 180, Agudeza visual: 20/20', TRUE),
(2, '-1.75', '-1.25', '170', '20/25', '-2.00', '-1.50', '175', '20/25', '70', 'Esfera: -1.75, Cilindro: -1.25, Eje: 170, Agudeza visual: 20/25', '-1.75', '-1.50', '175', '-1.75', '-1.50', '175', '70', 'Esfera: -1.75, Cilindro: -1.50, Eje: 175, Agudeza visual: 20/25', FALSE),
(3, '-3.00', '-0.50', '175', '20/20', '-2.75', '-0.75', '180', '20/20', '65', 'Esfera: -3.00, Cilindro: -0.50, Eje: 175, Agudeza visual: 20/20', '-2.75', '-0.75', '180', '-2.75', '-0.75', '180', '60', 'Esfera: -2.75, Cilindro: -0.75, Eje: 180, Agudeza visual: 20/20', TRUE),
(4, '-2.00', '-0.50', '170', '20/20', '-2.25', '-0.75', '175', '20/20', '70', 'Esfera: -2.00, Cilindro: -0.50, Eje: 170, Agudeza visual: 20/20', '-2.25', '-0.75', '175', '-2.25', '-0.75', '175', '70', 'Esfera: -2.25, Cilindro: -0.75, Eje: 175, Agudeza visual: 20/20', FALSE),
(5, '-1.50', '-1.00', '165', '20/25', '-1.75', '-1.25', '170', '20/25', '65', 'Esfera: -1.50, Cilindro: -1.00, Eje: 165, Agudeza visual: 20/25', '-1.75', '-1.25', '170', '-1.75', '-1.25', '170', '60', 'Esfera: -1.75, Cilindro: -1.25, Eje: 170, Agudeza visual: 20/25', TRUE);

-- MEDICACION
INSERT INTO Medicacion (idConsulta, idMedicamento, dosis, indicacion, ordenMedica) 
VALUES 
(1, 1, '1 tableta, cada 12 horas', 'Tomar con alimentos.', 'Amoxicilina 500 mg'),
(2, 2, '1 tableta, cada noche antes de dormir', 'Tomar con un vaso de agua.', 'Loratadina 10 mg'),
(3, 3, '1 gota en cada ojo, 3 veces al d�a', 'Aplicar despu�s de limpiar los ojos.', 'Colirio de ofloxacino'),
(4, 4, '2 tabletas, cada 8 horas', 'Tomar con el est�mago vac�o.', 'Ibuprofeno 400 mg'),
(5, 5, '1 tableta, cada ma�ana', 'Tomar con alimentos.', 'Vitamina C 1000 mg');

