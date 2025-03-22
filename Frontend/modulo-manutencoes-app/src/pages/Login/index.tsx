import { useState } from "react";
import DefaultTextField from "../../components/input/DefaultTextField";
import "./style/Login.css";
import { ILoginFormulario } from "./interface/ILoginFormulario";
import DefaultButton from "../../components/input/DefaultButton";
import Checkbox from "@mui/material/Checkbox";
import { FormControlLabel } from "@mui/material";

const Login = () => {
  const [formulario, setFormulario] = useState<ILoginFormulario>({
    email: "",
    senha: "",
  });

  return (
    <div className="login-container">
      <div className="card-login">
        <div className="login-logo-container">
          <img src="/favicon64x64.png" alt="Módulo de Manutenções" />
          <p style={{ fontSize: "2rem" }}>Login</p>
        </div>
        <div className="input-container-login">
          <DefaultTextField
            value={formulario.email}
            setValue={setFormulario}
            valueInObject={true}
            label="E-mail"
            name="email"
            className="mb-3"
          />
          <DefaultTextField
            value={formulario.senha}
            setValue={setFormulario}
            label="Senha"
            valueInObject={true}
            name="senha"
            type="password"
            className="mb-3"
          />
        </div>
        <div className="remember-me-container">
          <FormControlLabel
            control={
              <Checkbox
                sx={{
                  "&.Mui-checked": {
                    color: " #D32F2F",
                  },
                }}
              />
            }
            label="Lembrar-me"
          />
        </div>
        <div className="button-container-login">
          <DefaultButton>Entrar</DefaultButton>
        </div>
      </div>
    </div>
  );
};

export default Login;
