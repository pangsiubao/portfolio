const lijst = document.querySelector("#projecten-lijst");
const statusMelding = document.querySelector("#status");
const sorteerSelect = document.querySelector("#sorteer");

let alleProjecten = [];

const maakProjectKaart = (project) => {
  const item = document.createElement("li");

  const kaart = document.createElement("article");
  kaart.classList.add("card");

  const titel = document.createElement("h2");
  titel.textContent = project.titel;

  const beschrijving = document.createElement("p");
  beschrijving.textContent = project.beschrijving;

  const meta = document.createElement("footer");
  meta.classList.add("card-meta");

  const jaar = document.createElement("time");
  jaar.textContent = project.jaar;

  meta.append(project.taal + " · ", jaar);
  kaart.append(titel, beschrijving, meta);
  item.append(kaart);
  return item;
};

const toonProjecten = (projecten) => {
  lijst.innerHTML = "";
  projecten.forEach((project) => {
    lijst.append(maakProjectKaart(project));
  });
};

const sorteerProjecten = (projecten, volgorde) => {
  if (volgorde === "nieuw") {
    projecten.sort((a, b) => b.jaar - a.jaar);
  } else {
    projecten.sort((a, b) => a.jaar - b.jaar);
  }
};

const updateOverzicht = () => {
  sorteerProjecten(alleProjecten, sorteerSelect.value);
  toonProjecten(alleProjecten);
};

const laadProjecten = () => {
  fetch("data/projecten.json")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Bestand niet gevonden");
      }
      return response.json();
    })
    .then((data) => {
      alleProjecten = data;
      statusMelding.textContent = "";
      updateOverzicht();
    })
    .catch((fout) => {
      console.error("Projecten laden mislukt:", fout);
      statusMelding.textContent =
        "De projecten konden niet worden geladen. Ververs de pagina om het opnieuw te proberen.";
    });
};

sorteerSelect.addEventListener("change", updateOverzicht);
laadProjecten();