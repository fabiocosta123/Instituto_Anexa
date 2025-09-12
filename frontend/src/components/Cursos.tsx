// src/pages/cursos.js
import { useEffect, useState } from 'react';
import { getCursos } from '../services/cursosService';
import { Curso } from '../types/curso';

export default function CursosPage() {
  const [cursos, setCursos] = useState<Curso[]>([]);

  useEffect(() => {
    getCursos()
      .then(setCursos)
      .catch(err => console.error(err.message));
  }, []);

  return (
    <div>
      <h1>Lista de Cursos</h1>
      <ul>
        {cursos.map(c => (
          <li key={c.id}>{c.titulo}</li>
        ))}
      </ul>
    </div>
  );
}