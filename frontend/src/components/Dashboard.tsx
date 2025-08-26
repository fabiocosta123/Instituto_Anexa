'use client';

import { useEffect, useState } from "react";
import api from "../app/services/api";

interface Curso {
  id: number;
  titulo: string;
  descricao: string;
}


//verificação
useEffect(() => {
  const token = localStorage.getItem("token");
  if (!token) {
    router.push("/login");
  }
}, []);

export default function Dashboard() {
  const [cursos, setCursos] = useState<Curso[]>([]);

  useEffect(() => {
    const token = localStorage.getItem("token");

    api.get<Curso[]>("/Cursos", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    .then((res) => setCursos(res.data))
    .catch((err) => console.error("Erro ao buscar cursos", err));
  }, []);

  return (
    <div>
      <h2>Meus Cursos</h2>
      <ul>
        {cursos.map((curso) => (
          <li key={curso.id}>
            <strong>{curso.titulo}</strong><br />
            <span>{curso.descricao}</span>
          </li>
        ))}
      </ul>
    </div>
  );
}
