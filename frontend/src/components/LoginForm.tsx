"use client";

import { useState } from "react";
import axios from "axios";
import { useRouter } from "next/navigation";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "@/style/loginForm.css";

export default function LoginForm() {
  const router = useRouter();
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const handleLogin = async () => {
    if (!email && !senha) {
      toast.error("Campo usuário/senha estão vazios");
      return;
    }

    if (!email) {
      toast.error("Campo usuário não pode ser vazio");
      return;
    }

    if (!email.includes("@")) {
      toast.error("Digite um e-mail válido");
      return;
    }

    if (!senha) {
      toast.error("Campo senha não pode ser vazio");
      return;
    }

    try {
      const response = await axios.post<{ access_token: string }>(
        "http://localhost:5000/api/login",
        { email, senha }
      );

      const { access_token } = response.data;
      localStorage.setItem("token", access_token);
      router.push("/dashboard");
    } catch (err) {
      toast.error("Email ou senha inválidos");
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
      <button onClick={handleLogin} className="login-button">
        Entrar
      </button>

      {/* ✅ Toast container para exibir mensagens */}
      <ToastContainer position="top-right" autoClose={3000} />
    </div>
  );
}
