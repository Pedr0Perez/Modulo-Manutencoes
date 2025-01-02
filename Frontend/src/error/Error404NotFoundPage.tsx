import { useEffect } from "react";
import history from "../libs/history";
import alterarTitlePagina from "../utils/generic/alterarTitlePagina";

const Error404NotFoundPage = (): JSX.Element => {
  useEffect((): void => {
    console.error(
      "Failed to load resource: the server responded with a status of 404 ()"
    );
    alterarTitlePagina("404. Não encontrado.");
  });

  return (
    <>
      <p>404. Não encontrado.</p>
      <button
        onClick={(): void => {
          history.push("/");
          return;
        }}
      ></button>
    </>
  );
};

export default Error404NotFoundPage;
