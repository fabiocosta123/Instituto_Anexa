"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import axios from "axios";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "../style/registerForm.css";

import FormInput from "@/components/FormInput";

export default function RegisterForm() {
  const router = useRouter();
  const [loading, setLoading] = useState(false);
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

    const { rua, numero, bairro, cidade, estado, cep } = form.endereco;
    if (!rua) novosErros.rua = "Rua é obrigatória";
    if (!numero) novosErros.numero = "Número é obrigatório";
    if (!bairro) novosErros.bairro = "Bairro é obrigatório";
    if (!cidade) novosErros.cidade = "Cidade é obrigatória";
    if (!estado) novosErros.estado = "Estado é obrigatória";
    if (!cep) novosErros.cep = "CEP é obrigatório";

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
    if (loading) return;

    if (!validarFormulario()) {
      toast.error("Preencha todos os campos corretamente");
      return;
    }

    setLoading(true);

    try {
      await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/api/Usuarios`, form);
      toast.success("Usuário cadastrado com sucesso!");

      setTimeout(() => {
        router.push("/login");
      }, 1500);
    } catch (err) {
      console.error(err);
      toast.error("Erro ao cadastrar usuário");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="register-container">
      <h2>Cadastro de Usuário</h2>

      <FormInput
        name="nome"
        placeholder="Nome"
        value={form.nome}
        onChange={handleChange}
        error={errors.nome}
      />

      <FormInput
        name="email"
        placeholder="Email"
        value={form.email}
        onChange={handleChange}
        error={errors.email}
      />

      <FormInput
        name="cpf"
        placeholder="CPF"
        value={form.cpf}
        onChange={handleChange}
        error={errors.cpf}
      />

      <FormInput
        name="senha"
        placeholder="Senha"
        value={form.senha}
        onChange={handleChange}
        error={errors.senha}
        showToggle
      />

      <FormInput
        name="confirmarSenha"
        placeholder="Confirmar Senha"
        value={form.confirmarSenha}
        onChange={handleChange}
        error={errors.confirmarSenha}
        showToggle
      />

      {["rua", "numero", "bairro", "cidade", "estado", "cep"].map((campo) => (
        <FormInput
          key={campo}
          name={campo}
          placeholder={campo.charAt(0).toUpperCase() + campo.slice(1)}
          value={form.endereco[campo as keyof typeof form.endereco]}
          onChange={handleChange}
          error={errors[campo]}
        />
      ))}

      <button
        onClick={handleSubmit}
        className="register-button"
        disabled={loading}
      >
        {loading ? "Cadastrando..." : "Cadastrar"}
      </button>

      <ToastContainer position="top-right" autoClose={3000} />
    </div>
  );
}