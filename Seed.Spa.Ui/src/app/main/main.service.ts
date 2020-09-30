import { Injectable } from '@angular/core';
import { Observable, Observer, Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';

//import { ApiService } from 'app/common/services/api.service';
import { ApiService } from '../common/services/api.service';
import { ServiceBase } from '../common/services/service.base';
import { ViewModel } from '../common/model/viewmodel';
import { GlobalService } from '../global.service';
import { GlobalServiceCulture, Translated, TranslatedField } from '../global.service.culture';

@Injectable()
export class MainService extends ServiceBase {


  constructor(private globalServiceCulture: GlobalServiceCulture, private api: ApiService<any>) {
    super();
  }

  updateCulture(vm: any, culture: string = null) {
    this.getInfosTranslated(this.globalServiceCulture.defineCulture(culture)).then((result: any) => {
      vm.generalInfo = result;
    });
  }

  resetCulture() {
    this.globalServiceCulture.reset();
  }

  getInfosTranslated(culture: string) {
    return this.globalServiceCulture.getInfosTranslatedStrategy('Geral', culture, this.getInfos(), this.getTranslatedField());
  }

  getInfos() {
    return this.getInfosFields();
  }

  getTranslatedFieldFromJson() {

   

  }

  getTranslatedField(): TranslatedField[] {
    return [
      new TranslatedField("en-US", "nova", "New"),
      new TranslatedField("en-US", "buscar", "Search"),
      new TranslatedField("en-US", "voltar", "Come Back"),
      new TranslatedField("en-US", "sair", "Get Out"),
      new TranslatedField("en-US", "filtro", "Filter"),
      new TranslatedField("en-US", "novoItem", "New item"),
      new TranslatedField("en-US", "editarItem", "Edit Item"),
      new TranslatedField("en-US", "abrir", "Open"),
      new TranslatedField("en-US", "titulo", "Title"),
      new TranslatedField("en-US", "totalRegistro", "Total"),
      new TranslatedField("en-US", "proximo", "Near"),
      new TranslatedField("en-US", "anterior", "Previous"),
      new TranslatedField("en-US", "filtrar", "Filter"),
      new TranslatedField("en-US", "salvar", "Save"),
      new TranslatedField("en-US", "cancelar", "Cancel"),
      new TranslatedField("en-US", "sim", "Yer"),
      new TranslatedField("en-US", "imprimir", "Print"),
      new TranslatedField("en-US", "procurar", "Search"),
      new TranslatedField("en-US", "excluir", "delete"),
      new TranslatedField("en-US", "limpar", "Clear"),
      new TranslatedField("en-US", "importar", "import"),
    ]
  }

  getInfosFields() {
    return {
      nova: { label: 'Nova' },
      buscar: { label: 'Buscar' },
      voltar: { label: 'Voltar' },
      sair: { label: 'Sair' },
      filtro: { label: 'Filtros' },
      novoItem: { label: 'Novo item' },
      editarItem: { label: 'Editar item' },
      abrir: { label: 'Abrir' },
      titulo: { label: 'Titulo' },
      acao: { label: 'AÃ§Ã£o' },
      totalRegistro: { label: 'Total de registros' },
      proximo: { label: 'PrÃ³ximo' },
      anterior: { label: 'Anterior' },
      filtrar: { label: 'Filtrar' },
      salvar: { label: 'Salvar' },
      cancelar: { label: 'Cancelar' },
      sim: { label: 'Ok' },
      imprimir: { label: 'Imprimir' },
      procurar: { label: 'Procurar' },
      excluir: { label: 'Excluir' },
      limpar: { label: 'Limpar' },
      importar: { label: 'Importar' },
    }
  }

  transformTools(tools: any) {

    var source = JSON.parse(tools).filter((item) => { return item.Type == 1 });

    var parentItems = source.filter((item) => {
      return item.ParentKey == "" || !item.ParentKey
    }).map((item) => {
      return {
        name: item.Name,
        url: item.Route,
        icon: item.Icon,
        key: item.Key,
        parentkey: item.ParentKey,
        title: item.Title,
      }
    });

    var childrenItems = source.filter((item) => {
      return item.ParentKey != ""
    }).map((item) => {
      return {
        name: item.Name,
        url: item.Route,
        icon: item.Icon,
        parentkey: item.ParentKey,
        title: item.Title,
      }
    });

    var tools = parentItems.map((parentItem) => {

      var children = childrenItems.filter((childrenItem) => {
        return parentItem.key == childrenItem.parentkey
      });

      if (parentItem.title) {
        return {
          title: true,
          name: parentItem.name
        }
      }

      if (children && children.length > 0) {
        return {
          name: parentItem.name,
          url: parentItem.url ? parentItem.url : "/" + parentItem.name,
          icon: parentItem.icon,
          children: children
        }
      }

      return {
        name: parentItem.name,
        url: parentItem.url,
        icon: parentItem.icon,
      }

    });
 
    return tools;

  }
}
