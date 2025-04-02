import history from "../../libs/history/history";

const navigateAnchor = (
  e: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
  href: string | null | undefined
) => {
  if (href === null || href === undefined) {
    throw new Error('A props "href" é obrigatória.');
  }

  e.preventDefault();

  history.push(href!);
};

export default navigateAnchor;
