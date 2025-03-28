import { useMemo, useState } from "react";
import DefaultTextField from "../../components/input/DefaultTextField";
import "./style/Login.css";
import { ILoginFormulario } from "./interface/ILoginFormulario";
import DefaultButton from "../../components/input/DefaultButton";
import DefaultCheckbox from "../../components/input/DefaultCheckbox";
import api from "../../connection/Conexao-api";
import { ILoginSucessoResposta } from "./interface/ILoginSucessoResposta";
import DefaultLinearProgress from "../../components/progress/DefaultLinearProgress";
import iniciarSessao from "../../utils/sessao/iniciarSessao";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [formulario, setFormulario] = useState<ILoginFormulario>({
    email: "",
    senha: "",
  });

  const navigate = useNavigate();

  const formularioMemorizado = useMemo(() => formulario, [formulario]);

  const [lembrarMe, setLembrarMe] = useState<boolean>(false);

  const realizarAutenticacao = async () => {
    setExibirLoading(true);

    await api
      .post("/autenticacao", formulario)
      .then((response) => {
        const data: ILoginSucessoResposta = response.data;

        iniciarSessao(data);
        setExibirErroAutenticacao(false);
        navigate("/home");
      })
      .catch((err) => {
        console.error(err);
        setExibirErroAutenticacao(true);
      });

    setExibirLoading(false);
  };

  const [exibirErroAutenticacao, setExibirErroAutenticacao] =
    useState<boolean>(false);

  const [exibirLoading, setExibirLoading] = useState<boolean>(false);

  return (
    <div className="login-container">
      <div className="card-login">
        {exibirLoading && (
          <div className="linear-progress-login-container">
            <DefaultLinearProgress />
          </div>
        )}
        <div className="login-logo-container">
          <img src="/favicon64x64.png" alt="Módulo de Manutenções" />
          <p style={{ fontSize: "2rem" }}>Login</p>
        </div>
        <div className="input-container-login">
          <DefaultTextField
            value={formularioMemorizado.email}
            setValue={setFormulario}
            valueInObject={true}
            label="E-mail"
            name="email"
            className="mb-3"
            error={exibirErroAutenticacao}
            disabled={exibirLoading}
            type="email"
          />
          <DefaultTextField
            value={formularioMemorizado.senha}
            setValue={setFormulario}
            label="Senha"
            valueInObject={true}
            name="senha"
            type="password"
            className="mb-3"
            error={exibirErroAutenticacao}
            helperText={
              exibirErroAutenticacao
                ? "Credenciais incorretas. Tente novamente ou redefina sua senha."
                : ""
            }
            disabled={exibirLoading}
          />
        </div>
        <div className="remember-me-container">
          <DefaultCheckbox
            label="Lembrar-me"
            value={lembrarMe}
            setValue={setLembrarMe}
          />
        </div>
        <div className="button-container-login">
          <DefaultButton
            onClick={async () => await realizarAutenticacao()}
            disabled={
              formularioMemorizado.email === "" ||
              formularioMemorizado.senha === "" ||
              exibirLoading
            }
          >
            Entrar
          </DefaultButton>
        </div>
      </div>
    </div>
  );
};

export default Login;
