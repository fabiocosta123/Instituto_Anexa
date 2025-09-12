"use client";

import { FaEye, FaEyeSlash } from "react-icons/fa";
import { useState } from "react";

interface FormInputProps {
  name: string;
  type?: string;
  placeholder?: string;
  value?: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  error?: string;
  showToggle?: boolean;
}

export default function FormInput({
  name,
  type = "text",
  placeholder,
  value,
  onChange,
  error,
  showToggle = false,
}: FormInputProps) {
  const [show, setShow] = useState(false);
  const inputType = showToggle ? (show ? "text" : "password") : type;

  return (
    <div className="input-wrapper">
      <input
        name={name}
        type={inputType}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className={`register-input ${error ? "input-error" : ""}`}
      />
      {showToggle && (
        <button
          type="button"
          className="eye-button"
          onClick={() => setShow(!show)}
        >
          {show ? <FaEyeSlash /> : <FaEye />}
        </button>
      )}
      {error && <span className="error-text">{error}</span>}
    </div>
  );
}