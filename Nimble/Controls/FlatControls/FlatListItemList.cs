using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nimble.Controls.FlatControls
{
  public class FlatListItemList : List<FlatListItem>
  {
    public FlatList m_list;

    public FlatListItemList(FlatList list)
    {
      m_list = list;
    }

    public new void Insert(int index, FlatListItem fli)
    {
      base.Insert(index, fli);
      m_list.Invalidate();
      m_list.UpdateScrollbars();
    }

    public FlatListItem Add(string str)
    {
      FlatListItem item = new FlatListItem();
      item.Text = str;
      item.SubItems = new FlatListItemList(m_list);
      Add(item);
      m_list.Invalidate();
      m_list.UpdateScrollbars();
      return item;
    }

    public void Remove(int iIndex)
    {
      if (iIndex < 0 || iIndex >= Count) {
        return;
      }

      if (m_list._SelectedIndices.Contains(iIndex)) {
        m_list.Deselect(iIndex);
      } else {
        for (int i = 0; i < m_list._SelectedIndices.Length; i++) {
          if (m_list._SelectedIndices[i] > iIndex) {
            m_list._SelectedIndices[i]--;
          }
        }
      }

      RemoveAt(iIndex);
      m_list.Invalidate();
      m_list.UpdateScrollbars();
    }

    public new void Remove(FlatListItem fli)
    {
      int iIndex = IndexOf(fli);
      if (iIndex < 0 || iIndex >= Count) {
        return;
      }

      if (m_list._SelectedIndices.Contains(iIndex)) {
        m_list.Deselect(iIndex);
      } else {
        for (int i = 0; i < m_list._SelectedIndices.Length; i++) {
          if (m_list._SelectedIndices[i] > iIndex) {
            m_list._SelectedIndices[i]--;
          }
        }
      }

      base.Remove(fli);
      m_list.Invalidate();
      m_list.UpdateScrollbars();
    }
  }
}
