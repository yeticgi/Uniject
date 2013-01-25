using System;

namespace Uniject
{
  public interface IGui
  {
    string TextArea(Rect position, string text, int maxLength);
    string TextField(Rect position, string text, int maxLength);
    void SetNextControlName(string name);
    void FocusControl(string name);
  }
}
