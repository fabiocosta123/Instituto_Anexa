"use client";
import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { toast } from "react-toastify";
import api from "../app/services/api";
import "../styles/dashboard.css";

interface Curso {
  id: number;
  titulo: string;
  descricao: string;
}

export default function Dashboard() {
  const router = useRouter();
  const [cursos, setCursos] = useState<Curso[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchCursos = async () => {
      const token = localStorage.getItem("token");
      if (!token) {
        router.push("/login");
        return;
      }

      try {
        const res = await api.get<Curso[]>("/Cursos", {
          headers: { Authorization: `Bearer ${token}` },
        });
        setCursos(res.data);
      } catch {
        toast.error("Erro ao carregar cursos");
      } finally {
        setLoading(false);
      }
    };

    fetchCursos();
  }, [router]);

  return (
    <div className="dashboard-container">
      {loading ? (
        <p>Carregando cursos...</p>
      ) : (
        <ul>
          {cursos.map((curso) => (
            <li key={curso.id}>
              <strong>{curso.titulo}</strong>
              <br />
              <span>{curso.descricao}</span>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
