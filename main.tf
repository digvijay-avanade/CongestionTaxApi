provider "azurerm" {
  skip_provider_registration = true
    features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "rgTerraform"
        storage_account_name = "tfstatestorageava"
        container_name       = "contoso"
        key                  = "terraform.tfstate"
    }
}

variable "imagebuild" {
  type        = string
  description = "Build Latest Docker Image for Congestion Tax API"
}



resource "azurerm_resource_group" "tf_contoso" {
  name = "rgContoso"
  location = "Sweden Central"
}

resource "azurerm_container_group" "tf_contoso_container_group" {
  name                      = "congestiontaxapi"
  location                  = azurerm_resource_group.tf_contoso.location
  resource_group_name       = azurerm_resource_group.tf_contoso.name

  ip_address_type     = "Public"
  dns_name_label      = "congestiontaxapi"
  os_type             = "Linux"

  container {
    name            = "congestiontaxapi"
    image           = "digvijayava/congestiontaxapi:${var.imagebuild}"
    cpu             = "1"
    memory          = "1"

    ports {
        port        = 80
        protocol    = "TCP"
    }
  }
}