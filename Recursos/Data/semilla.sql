INSERT INTO Usuarios (nombre, correo, clave, cargo, especialidad)
VALUES ('Jazmin Perez', 'jazmin@example.com', 'bb8b810d769f92ba3b6576e95be930cf2e6147b91de0d085a47fcb42b8bae20f', 'Médico', 'Pediatría'); 
INSERT INTO Usuarios (nombre, correo, clave, cargo, especialidad)
VALUES ('Omar Lujan', 'omar@example.com', 'bb8b810d769f92ba3b6576e95be930cf2e6147b91de0d085a47fcb42b8bae20f', 'Médico', 'Pediatría'); 

INSERT INTO Laboratorios (nombre) VALUES ('Laboratorio Clínico Central');
INSERT INTO Laboratorios (nombre) VALUES ('Laboratorio de Microbiología');

INSERT INTO Presentaciones (nombre) VALUES ('Tableta');
INSERT INTO Presentaciones (nombre) VALUES ('Cápsula');

INSERT INTO Cies (codigo, nombre) VALUES ('H25', 'Catarata senil');
INSERT INTO Cies (codigo, nombre) VALUES ('H40', 'Glaucoma');

INSERT INTO Examenes (nombre) VALUES ('Conteo de células sanguíneas');
INSERT INTO Examenes (nombre, tipo) VALUES ('Glucosa en sangre', 'especial');

INSERT INTO Seguros (nombre) VALUES ('Seguros Bolívar');
INSERT INTO Seguros (nombre) VALUES ('Seguros del Estado');

INSERT INTO Ocupaciones (nombre, detalle) VALUES ('Ingeniero sis', 'hace weas de computadoras');
INSERT INTO Ocupaciones (nombre) VALUES ('narco');

INSERT INTO Medicamentos (codigo, generico,comercial,dosis,indicacion,stock,costo,ubicacion,estado,idPresentacion, idLaboratorio) VALUES
('MED001', 'Paracetamol', 'Tylenol', '500mg', 'Analgesico y antipiretico', 1, 1,'segundo estante','2',1,1),
('MED002', 'Paracetamol', 'Panadol', '500mg', 'Analgesico y antipiretico', 2, 2,'estante princpal','2',1,1),
('MED003', 'Ibuprofeno', 'Advil', '200mg', 'Antiinflamatorio y analgesico',1, 3,'deposito','1',2,2);

INSERT INTO Diabetes (nombre, detalle) VALUES 
('tipo 1(DM1)', 'Se produce cuando el páncreas no produce suficiente insulina.'),
('tipo 2(DM2)', 'Se produce cuando el cuerpo no puede usar la insulina de manera efectiva.'),
('gestacional(DG)', 'Se desarrolla durante el embarazo y puede desaparecer después del parto.'),
('Otras (OD)', 'otros tipos de diabetes.');

INSERT INTO Alergias (nombre) VALUES ('Polen');
INSERT INTO Alergias (nombre) VALUES ('Ácaros del polvo');
INSERT INTO Alergias (nombre) VALUES ('Moho');
INSERT INTO Alergias (nombre) VALUES ('Caspa de animales');
INSERT INTO Alergias (nombre) VALUES ('Alimentos');


INSERT INTO Departamentos VALUES ('1', 'AMAZONAS');
INSERT INTO Departamentos VALUES ('2', 'ANCASH');
INSERT INTO Departamentos VALUES ('3', 'APURIMAC');
INSERT INTO Departamentos VALUES ('4', 'AREQUIPA');

INSERT INTO Provincias VALUES ('1', 'CHACHAPOYAS', '1');
INSERT INTO Provincias VALUES ('2', 'BAGUA', '2');
INSERT INTO Provincias VALUES ('3', 'BONGARA', '3');
INSERT INTO Provincias VALUES ('4', 'CONDORCANQUI', '4');

INSERT INTO Distritos VALUES ('1', 'CHACHAPOYAS', '1');
INSERT INTO Distritos VALUES ('2', 'ASUNCION', '2');
INSERT INTO Distritos VALUES ('3', 'BALSAS', '3');
INSERT INTO Distritos VALUES ('4', 'CHETO', '4');

INSERT INTO Parentescos (NOMBRE) VALUES('padre'),('madre'),('otro');

INSERT INTO Pacientes (condicion,primerNombre,aPaterno, aMaterno,tipoDocumento, numeroDocumento, fechaNacimiento, edad, sexo, estadoCivil,
grupoSanguineo, nacionalidad, idDepartamento, idProvincia, idDistrito, direccion, telefono, celular,email,idOcupacion,centroTrabajo,isAsegurado,
idSeguro,numerocarnet,perfil,isAlergico,isDiabetico,isDelete)
VALUES ('0', 'Jazmin','Perez', 'Sarmiento','0', '12345678', '2003-02-21', '20','F', '0', '0', '0', 1, 1, 1, 'Av. Los Pinos 123', '01-2345678', '987654321',
'jaz@example.com', 1,null,true,1,'122212',null,true,true,false);

INSERT INTO contactos(nombre,idPaciente,idParentesco,isDelete) VALUES('juan',1,1,true), ('omar',1,3,false);

INSERT INTO Antecedentes(idPaciente,antecedentesClinicos,idDiabete) VALUES (1,'alcholica',1);

INSERT INTO DetalleAlergias (idAlergia,idAntecedente,reacciones)VALUES (1,1,'ronchas');
INSERT INTO DetalleAlergias (idAlergia,idAntecedente,reacciones)VALUES (2,1,'muere');

select p.primerNombre,p.aPaterno,p.isAsegurado,s.nombre,p.numeroCarnet,p.isAlergico,al.nombre,d.reacciones,p.isDiabetico,di.nombre,a.antecedentesClinicos,c.nombre,c.telefono
 from pacientes p inner join contactos c on p.id=c.idPaciente
 inner join seguros s on p.idSeguro=s.id
 inner join Antecedentes a on p.id=a.idpaciente
 inner join diabetes di on a.idDiabete = di.id
 inner join DetalleAlergias d on d.idAntecedente=a.id
 inner join alergias al on d.idAlergia=al.id
 where p.idSeguro=s.id and c.nombre='omar'
 
 

