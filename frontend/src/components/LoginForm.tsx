'use client';

import { useState } from "react";
import axios from "axios";
import { useRouter } from "next/navigation";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import "@/style/loginForm.css";

export default function LoginForm() {
  const API_URL = process.env.NEXT_PUBLIC_API_URL ?? "";
  const router = useRouter();

  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [showSenhaLogin, setShowSenhaLogin] = useState(false);

  const handleLogin = async () => {
    // 1) Validações antes da chamada
    if (!email && !senha) {
      toast.error("Campos de usuário e senha estão vazios");
      return;
    }
    if (!email) {
      toast.error("Campo email não pode ser vazio");
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

    // 2) Requisição ao backend com try/catch
    try {
      const { data: { access_token } } = await axios.post<{ access_token: string }>(
        `${API_URL}/api/login`,
        { email, senha }
      );

      // 3) Armazena token e redireciona
      localStorage.setItem("token", access_token);
      toast.success("Login efetuado com sucesso!");
      router.push("/dashboard");

    } catch (err) {
      console.error(err);
      toast.error("Email ou senha inválidos");
    }
  };

  return (
    <div className="login-container">
      <h1 className="login-title">Acesso ao Sistema</h1>

      <input
        type="email"
        value={email}
        onChange={e => setEmail(e.target.value)}
        placeholder="Email"
        className="login-input"
      />

      <div className="input-wrapper">
        <input
          type={showSenhaLogin ? "text" : "password"}
          value={senha}
          onChange={e => setSenha(e.target.value)}
          placeholder="Senha"
          className="login-input"
        />
        <button
          type="button"
          className="eye-button"
          onClick={() => setShowSenhaLogin(prev => !prev)}
        >
          {showSenhaLogin ? <FaEyeSlash /> : <FaEye />}
        </button>
      </div>

      <button onClick={handleLogin} className="login-button">
        Entrar
      </button>

      <ToastContainer position="top-right" autoClose={3000} />
    </div>
  );
}
