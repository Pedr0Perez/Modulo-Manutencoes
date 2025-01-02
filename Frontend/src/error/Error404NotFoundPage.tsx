import history from "../libs/history";
import alterarTitlePagina from "../utils/generic/alterarTitlePagina";

const Error404NotFoundPage = (): JSX.Element => {
  alterarTitlePagina("404. Não encontrado.");

  console.error(
    "Failed to load resource: the server responded with a status of 404 ()"
  );

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
