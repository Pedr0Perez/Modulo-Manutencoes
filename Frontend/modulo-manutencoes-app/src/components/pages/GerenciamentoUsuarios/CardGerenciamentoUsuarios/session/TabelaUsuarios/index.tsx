import { memo, useEffect, useState } from "react";
import DefaultTable from "../../../../../panel/DefaultTable";
import api from "../../../../../../connection/Conexao-api";

interface IUsuario {
  id: number;
  primeiroNome: string;
  sobrenome: string;
  email: string;
  email2: string | null;
  senha: null;
  dataNascimento: Date | null;
  genero: "M" | "F" | "E";
  pais: string | null;
  cidade: string | null;
  estado: string | null;
}

const TabelaUsuarios = () => {
  const [listaUsuarios, setListaUsuarios] = useState<IUsuario[]>([]);

  const buscarListaUsuarios = async () => {
    await api
      .get("/usuario")
      .then((resp) => {
        setListaUsuarios(resp.data);
      })
      .catch((err) => {
        console.error(err);
      });
  };

  useEffect(() => {
    buscarListaUsuarios();
  }, []);

  const generoXsigla = {
    M: "Masculino",
    F: "Feminino",
    E: "Não especificado",
  } as const;

  return (
    <DefaultTable
      list={listaUsuarios?.map((user) => ({
        id: user.id,
        nome: `${user.primeiroNome} ${user.sobrenome}`,
        email: user.email,
        genero: generoXsigla[user.genero],
        pais: user.pais || "Não cadastrado",
        estado: user.estado || "Não cadastrado",
        cidade: user.cidade || "Não cadastrado",
        acoes: (
          <div className="table-btn">
            <button>+</button>
          </div>
        ),
      }))}
      columnsList={[
        "ID",
        "Nome",
        "E-mail",
        "Gênero",
        "País",
        "Estado",
        "Cidade",
        "",
      ]}
    ></DefaultTable>
  );
};

export default memo(TabelaUsuarios);
