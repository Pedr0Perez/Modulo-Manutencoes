export default function alterarTitlePagina(value: string): void {
  const title: HTMLTitleElement = document.querySelector("title")!;

  title.innerText = `${value !== "" ? value + " / " : ""}Módulo de Manutenções`;
}
