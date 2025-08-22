'use client';

import { useState } from 'react';
import './cursos.css';

const cursos = [
  { id: 1, nome: 'Matemática' },
  { id: 2, nome: 'História' },
  { id: 3, nome: 'Biologia' },
  { id: 4, nome: 'Física' },
  { id: 5, nome: 'Programação' },
];

export default function CursosPage() {
  const [hoveredId, setHoveredId] = useState<number | null>(null);

  return (
    <div className="cursos-container">
      <h1 className="cursos-title">Nossos Cursos</h1>
      <div className="cursos-grid">
        {cursos.map((curso) => (
          <div
            key={curso.id}
            className={`curso-card ${hoveredId === curso.id ? 'hovered' : hoveredId !== null ? 'dimmed' : ''}`}
            onMouseEnter={() => setHoveredId(curso.id)}
            onMouseLeave={() => setHoveredId(null)}
          >
            {curso.nome}
          </div>
        ))}
      </div>
    </div>
  );
}
