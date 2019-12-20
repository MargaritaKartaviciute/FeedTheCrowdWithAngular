import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { RecipeComponent } from './recipe/recipe.component';
import { ProfileComponent } from './profile/profile.component';
import { NewRecipeComponent } from './newRecipe/newRecipe.componet';
import { CreateEventComponent } from './event/create-event/create-event.component';
import { EventComponent } from './event/event/event.component';
import { OwnRecipesComponent } from './ownRecipes/ownRecipes.component';
import { AuthGuard } from './../guards/auth.guards';
import { EditRecipeComponent } from './editRecipe/editRecipe.component';
import { ProductDetailResolve } from '../../services/product/product-detail.resolve.service';
import { RecipeDetailResolve } from '../../services/recipe/recipe-detail.resolve.service';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'recipes/:id',
    component: RecipeComponent
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'newRecipe',
    component: NewRecipeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'createEvent',
    component: CreateEventComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'event/:id',
    component: EventComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'ownRecipes',
    component: OwnRecipesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'editRecipe/:id',
    component: EditRecipeComponent,
    resolve: {
      recipe: RecipeDetailResolve,
      products: ProductDetailResolve
    },
    canActivate: [AuthGuard],
  },

  // otherwise redirect to home
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    ProductDetailResolve,
    RecipeDetailResolve
  ]
})
export class AppRoutingModule { }
