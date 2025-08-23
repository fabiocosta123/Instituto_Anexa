'use client';

import { useState } from "react";
import axios from "axios";
import { useRouter } from "next/navigation";
import "@/style/loginForm.css"; // importa o CSS

export default function LoginForm() {
  const router = useRouter();
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [erro, setErro] = useState("");

  const handleLogin = async () => {
    try {
      const response = await axios.post<{ access_token: string }>(
        "http://localhost:5000/api/login",
        { email, senha }
      );
      const { access_token } = response.data;
      localStorage.setItem("token", access_token);
      setErro("");
      router.push("/dashboard");
    } catch (err) {
      setErro("Email ou senha inválidos");
    }
  };

  return (
    <div className="login-container">
      <h1 className="login-title">Acesso ao Sistema</h1>
      <input
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="Email"
        className="login-input"
      />
      <input
        type="password"
        value={senha}
        onChange={(e) => setSenha(e.target.value)}
        placeholder="Senha"
        className="login-input"
      />
      {erro && <p className="login-error">{erro}</p>}
      <button onClick={handleLogin} className="login-button">
        Entrar
      </button>
    </div>
  );
}
