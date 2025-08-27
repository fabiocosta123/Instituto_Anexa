"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import axios from "axios";
import { toast, ToastContainer } from "react-toastify";
import { FaEye, FaEyeSlash } from "react-icons/fa";

import "react-toastify/dist/ReactToastify.css";
import "../style/registerForm.css";

export default function RegisterForm() {
  const router = useRouter();

  const [showSenha, setShowSenha] = useState(false);
  const [showConfirmarSenha, setShowConfirmarSenha] = useState(false);

  const [errors, setErrors] = useState<{ [key: string]: string }>({});

  const [form, setForm] = useState({
    nome: "",
    email: "",
    cpf: "",
    senha: "",
    confirmarSenha: "",
    endereco: {
      rua: "",
      numero: "",
      bairro: "",
      cidade: "",
      estado: "",
      cep: "",
    },
  });

  const validarFormulario = () => {
    const novosErros: { [key: string]: string } = {};

    if (!form.nome) novosErros.nome = "Nome é obrigatório";
    if (!form.email || !form.email.includes("@"))
      novosErros.email = "Email inválido";
    if (!form.cpf || form.cpf.length !== 11)
      novosErros.cpf = "CPF deve ter 11 dígitos";
    if (!form.senha || form.senha.length < 6)
      novosErros.senha = "Senha deve ter pelo menos 6 caracteres";

    if (!form.confirmarSenha) {
      novosErros.confirmarSenha = "Confirme sua senha";
    } else if (form.senha !== form.confirmarSenha) {
      novosErros.confirmarSenha = "As senhas não coincidem";
    }

    const endereco = form.endereco;
    if (!endereco.rua) novosErros.rua = "Rua é obrigatória";
    if (!endereco.numero) novosErros.numero = "Número é obrigatório";
    if (!endereco.bairro) novosErros.bairro = "Bairro é obrigatório";
    if (!endereco.cidade) novosErros.cidade = "Cidade é obrigatória";
    if (!endereco.estado) novosErros.estado = "Estado é obrigatório";
    if (!endereco.cep) novosErros.cep = "CEP é obrigatório";

    setErrors(novosErros);
    return Object.keys(novosErros).length === 0;
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    if (name in form.endereco) {
      setForm({ ...form, endereco: { ...form.endereco, [name]: value } });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const handleSubmit = async () => {
    if (!validarFormulario()) {
      toast.error("Preencha todos os campos corretamente");
      return;
    }

    try {
      await axios.post("https://localhost:7123/api/Usuarios", form);
      toast.success("Usuário cadastrado com sucesso!");

      setTimeout(() => {
        router.push("/login");
      }, 1500);
    } catch (err) {
      toast.error("Erro ao cadastrar usuário");
    }
  };

  return (
    <div className="register-container">
      <h2>Cadastro de Usuário</h2>
      <input
        name="nome"
        placeholder="Nome"
        onChange={handleChange}
        className={`register-input ${errors.name ? "input-error" : ""}`}
      />
      {errors.name && <span className="error-text">{errors.name}</span>}

      <input
        name="email"
        placeholder="Email"
        onChange={handleChange}
         className={`register-input ${errors.email ? "input-error" : ""}`}
      />
      {errors.email && <span className="error-text">{errors.email}</span>}

      <input
        name="cpf"
        placeholder="CPF"
        onChange={handleChange}
         className={`register-input ${errors.cpf ? "input-error" : ""}`}
      />
      {errors.cpf && <span className="error-text">{errors.cpf}</span>}

      <div className="input-wrapper">
        <input
          type={showSenha ? "text" : "password"}
          name="senha"
          placeholder="Senha"
          onChange={handleChange}
          className={errors.senha ? "input-error" : ""}
        />
        <button
          type="button"
          className="eye-button"
          onClick={() => setShowSenha(!showSenha)}
        >
          {showSenha ? <FaEyeSlash /> : <FaEye />}
        </button>
      </div>
      {errors.senha && <span className="error-text">{errors.senha}</span>}

      <div className="input-wrapper">
        <input
          type={showConfirmarSenha ? "text" : "password"}
          name="confirmarSenha"
          placeholder="Confirmar Senha"
          onChange={handleChange}
          className={errors.confirmarSenha ? "input-error" : ""}
        />
        <button
          type="button"
          className="eye-button"
          onClick={() => setShowConfirmarSenha(!showConfirmarSenha)}
        >
          {showConfirmarSenha ? <FaEyeSlash /> : <FaEye />}
        </button>
      </div>
      {errors.confirmarSenha && (
        <span className="error-text">{errors.confirmarSenha}</span>
      )}

      <input name="rua" placeholder="Rua" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`}/>
      <input name="numero" placeholder="Número" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`} />
      <input name="bairro" placeholder="Bairro" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`} />
      <input name="cidade" placeholder="Cidade" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`} />
      <input name="estado" placeholder="Estado" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`} />
      <input name="cep" placeholder="CEP" onChange={handleChange}  className={`register-input ${errors.nome ? "input-error" : ""}`} />
      <button onClick={handleSubmit} className="register-button">Cadastrar</button>
      <ToastContainer position="top-right" autoClose={3000} />
    </div>
  );
}
