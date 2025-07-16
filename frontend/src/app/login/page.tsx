'use client';

import { useState } from "react";
import axios from "axios";
import { useRouter } from "next/navigation";

export default function LoginPage() {
    const router = useRouter();
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [erro, setErro] = useState("");

    const handleLogin = async () => {
    try {
      const response = await axios.post<{ access_token: string}>('http://localhost:5000/api/login', {
        email,
        senha,
      });

      const { access_token } = response.data;
      localStorage.setItem('token', access_token);
      setErro('');
      router.push('/dashboard'); // redireciona após login
    } catch (err) {
      setErro('Email ou senha inválidos');
    }
  };

  return (
    <main className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded shadow-lg w-96">
        <h1 className="text-2xl font-bold mb-4 text-center">Login</h1>
        <input
          type="email"
          value={email}
          onChange={e => setEmail(e.target.value)}
          placeholder="Email"
          className="w-full mb-3 p-2 border rounded"
        />
        <input
          type="password"
          value={senha}
          onChange={e => setSenha(e.target.value)}
          placeholder="Senha"
          className="w-full mb-3 p-2 border rounded"
        />
        {erro && <p className="text-red-500 mb-2 text-sm">{erro}</p>}
        <button
          onClick={handleLogin}
          className="w-full bg-blue-600 text-white p-2 rounded hover:bg-blue-700 cursor-pointer transition-colors"
        >
          Entrar
        </button>
      </div>
    </main>
  );

}